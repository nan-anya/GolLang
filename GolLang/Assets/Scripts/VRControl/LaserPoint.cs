using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPoint : MonoBehaviour
{
    // 컨트롤러 구분
    public SteamVR_Input_Sources handType;

    // 컨트롤러
    public SteamVR_Behaviour_Pose controllerPose;

    // 터치패드 클릭
    public SteamVR_Action_Boolean teleportAction;

    //public SteamVR_Action_Boolean triggerAction;

    // 레이저 오브젝트
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    private float defaultLength = 10.0f;

    // 레이저 끝부분
    private GameObject reticle;
    public GameObject teleportReticlePrefab;
    private Transform teleportReticleTransform;

    // vr 전체
    public Transform cameraRigTransform;
    
    // vr 카메라
    public Transform headTransform;
    public Vector3 teleportReticleOffset;

    // 텔레포트 구역 구분
    public LayerMask teleportMask;
    private bool canTeleport;


     // Start is called before the first frame update
    void Start()
    {
        // 레이저 초기화
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;

        // 끝 부분
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLaser();
    }
    /*
    void UpdateTrigger()
    {
        if(triggerAction.GetStateDown(handType))
        {
            Debug.Log("Trigger");

            RaycastHit hit;
            Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100);

            hitPoint = controllerPose.transform.position + (transform.forward * defaultLength);

            // 레이저 충돌
            if (hit.collider != null)
            {
                hitPoint = hit.point;
                Debug.Log(hit.collider.name);
            }

            ShowLaser0();
        }
        else
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }
    }
    */

    void UpdateLaser()
    {
        // 한 컨트롤러의 터치패드 상태가 눌려짐 검사
        // 눌러졌으면 레이저 위치 계산
        if (teleportAction.GetState(handType))
        {
            // 충돌 검사
            RaycastHit hit;
            Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100);

            hitPoint = controllerPose.transform.position + (transform.forward * defaultLength);

            // 레이저 충돌
            if(hit.collider != null)
            {
                hitPoint = hit.point;
                canTeleport = CheckTeleport(hit);
                //Debug.Log(hit.collider.name);
            }
            else
            {
                canTeleport = false;
            }

            ShowLaser0();
        }
        /*
        // 트리거 동작
        else if (triggerAction.GetState(handType))
        {
            Debug.Log("Trigger");

            RaycastHit hit;
            Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100);

            hitPoint = controllerPose.transform.position + (transform.forward * defaultLength);

            // 레이저 충돌
            if (hit.collider != null)
            {
                hitPoint = hit.point;
                Debug.Log(hit.collider.name);
            }

            ShowLaser0();
        }
        */
        else
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }

        if (teleportAction.GetStateUp(handType) && canTeleport)
        {
            //Debug.Log("TELEPORT");
            Teleport();
        }
    }

    private bool CheckTeleport(RaycastHit hit)
    {
        //Debug.Log(LayerMask.NameToLayer("CanTeleport") + " now");
        return (CheckLayer(hit) == LayerMask.NameToLayer("CanTeleport")) ;
    }

    private int CheckLayer(RaycastHit hit)
    {
        //Debug.Log("Layer : " + hit.collider.gameObject.layer);
        return hit.collider.gameObject.layer;
    }

    private void ShowLaser0()
    {
        laser.SetActive(true);
        laser.transform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, 0.5f);
        laserTransform.LookAt(hitPoint);

        float distance = Vector3.Distance(controllerPose.transform.position, hitPoint);

        laser.transform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, distance);

        reticle.SetActive(true);
        teleportReticleTransform.position = hitPoint + teleportReticleOffset;
    }
    
    private void Teleport()
    {
        //Debug.Log("Teleport");

        canTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }
}
