using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    // 컨트롤러에 연결된 카메라
    public Camera m_Camera;

    // 입력 컨트롤러
    public SteamVR_Input_Sources m_TargetSource;

    // 액션, 텔레포트(터치패드 클릭)
    public SteamVR_Action_Boolean m_ClickAction;

    private GameObject m_CurrentObject = null;

    // 클릭/터치 정보(캔버스 상), 레이저 포인터에 전달
    private PointerEventData m_Data = null;

    protected override void Awake()
    {
        base.Awake();

        m_Data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        // 카메라 중간 위치
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);

        // 레이저에 닿은 UI 찾음
        // BaseInputModule 에서 제공,
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);  // 현재 이벤트와 연관된 RacastResult
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;              // 레이저로 가리키는 오브젝트

        m_RaycastResultCache.Clear();

        // 입출력 이벤트 전송
        // 호버링(마우스 포인터가 해당 컨트롤 위에 있음)
        HandlePointerExitAndEnter(m_Data, m_CurrentObject);

        // 터치패드 누를 때
        if(m_ClickAction.GetStateDown(m_TargetSource))
        {
            ProcessPress(m_Data);
        }

        // 터치패드 뗄 때
        if(m_ClickAction.GetStateUp(m_TargetSource))
        {
            ProcessRelease(m_Data);
        }
    }

    public PointerEventData GetData()
    {
        return m_Data;
    }

    // 터치패드 누름
    private void ProcessPress(PointerEventData data)
    {
        // 포인터 프레스 결과
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // hit 검사, down 핸들러 가져오고, 호출
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_CurrentObject, data, ExecuteEvents.pointerDownHandler);

        // down 핸들러 없으면 클릭 핸들러
        if(newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);
        }

        // 데이터 설정
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = m_CurrentObject;
    }

    private void ProcessRelease(PointerEventData data)
    {
        // 포인터 업 실행
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        // 클릭 핸들러 검사
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);

        // 
        if(data.pointerPress  == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        eventSystem.SetSelectedGameObject(null);

        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }

}
