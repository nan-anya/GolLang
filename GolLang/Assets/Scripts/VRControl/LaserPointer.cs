using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserPointer : MonoBehaviour
{
    public float m_DefaultLength = 5.0f;

    // 끝 점
    public GameObject m_Dot;

    public VRInputModule m_InputModule;

    // 선 그리기
    private LineRenderer m_LineRender = null;

    private void Awake()
    {
        m_LineRender = GetComponent<LineRenderer>();
    }

    private void UpdateLine()
    {
        // 이벤트 가져오기
        PointerEventData data = m_InputModule.GetData();

        // 거리 구하기
        // 닿는게 없으면 기본거리, 있으면 닿은 점까지 거리
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLength : data.pointerCurrentRaycast.distance;
        // float targetLength = m_DefaultLength;

        // 히트 정보
        RaycastHit hit = CreateRaycast(targetLength);

        // 레이저 끝나는 지점 계산
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        // 히트가 있으면 히트한 지점
        if(hit.collider != null)
        {
            endPosition = hit.point;
        }

        // 끝점 위치
        m_Dot.transform.position = endPosition;

        // 레이저 그리기
        m_LineRender.SetPosition(0, transform.position);
        m_LineRender.SetPosition(1, endPosition);
    }

    // 
    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;

        // 레이저,(시작, 방향)
        Ray ray = new Ray(transform.position, transform.forward);

        // Raycast(레이저, 히트, 거리)
        Physics.Raycast(ray, out hit, m_DefaultLength);

        // 결과 리턴
        return hit;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }
}
