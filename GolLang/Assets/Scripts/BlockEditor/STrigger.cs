﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STrigger : MonoBehaviour
{
    public bool attachable = true;

    public bool detachable = false;

    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag.Contains("Block") && attachable)
        {
            transform.parent.GetComponent<Block>().siblingTrigger(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
