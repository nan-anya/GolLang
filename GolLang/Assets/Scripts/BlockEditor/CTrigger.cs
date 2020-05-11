using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger : MonoBehaviour
{
    public bool attachable = true;

    public bool detachable = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Block") && attachable)
        {
            transform.parent.GetComponent<Block>().childTrigger(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
