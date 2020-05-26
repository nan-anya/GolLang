using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTrigger : MonoBehaviour
{
    public Block rightBlock = null;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Contains("Block") && rightBlock == null)
        {
            transform.parent.GetComponent<Block>().rightTriggerIn(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (rightBlock != null && rightBlock == other.gameObject.GetComponent<Block>())
        {
            transform.parent.GetComponent<Block>().rightTriggerOut();
        }
    }
}
