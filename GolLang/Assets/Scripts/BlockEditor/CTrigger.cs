using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger : MonoBehaviour
{
    public Block childBlock = null;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Contains("Block") && childBlock == null)
        {
            transform.parent.GetComponent<Block>().childTriggerIn(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (childBlock != null && childBlock == other.gameObject.GetComponent<Block>())
        {
            transform.parent.GetComponent<Block>().childTriggerOut();
        }
    }
}
