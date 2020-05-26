using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STrigger : MonoBehaviour
{
    public Block siblingBlock = null;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Contains("Block") && siblingBlock == null && !transform.parent.GetComponent<Block>().inMiddle)
        {
            transform.parent.GetComponent<Block>().siblingTriggerIn(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (siblingBlock != null && siblingBlock == other.gameObject.GetComponent<Block>())
        {
            transform.parent.GetComponent<Block>().siblingTriggerOut();
        }
    }
}
