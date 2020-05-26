using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Block"))
        {
            Destroy(other.gameObject);
        }
    }
}
