using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabBlock : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean triggerAction;

    private GameObject CollidingObject;
    private GameObject objectInHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerAction.GetStateDown(handType))
        {
            //Debug.Log("Trigger Down");
            if(CollidingObject)
            {
                //Debug.Log("Grab");
                GrabObject();
            }
        }

        if(triggerAction.GetStateUp(handType))
        {
            //Debug.Log("Trigger Up");
            if(objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collid " + other.name);
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if(!CollidingObject)
        {
            return;
        }

        CollidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        Block b = col.GetComponent<Block>();

        if (b == null || b.haveChild || b.haveSibling || b.haveRight)
        {
            return;
        }

        if(CollidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        CollidingObject = col.gameObject;
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;

        return fx;
    }

    private void GrabObject()
    {
        objectInHand = CollidingObject;
        CollidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        objectInHand.tag = "Grabed";
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            //objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

            // 블럭 놓고 조립
            // 이름조심
            //GameObject.Find(objectInHand.name).GetComponent<Block>().CheckReleased();
            GameObject.Find(objectInHand.name).transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            GameObject.Find(objectInHand.name).transform.localPosition = new Vector3(GameObject.Find(objectInHand.name).transform.localPosition.x, GameObject.Find(objectInHand.name).transform.localPosition.y, 0);
        }

        objectInHand.tag = "Block";

        objectInHand = null;
    }
}