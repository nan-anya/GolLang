﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private bool CanSnap;
    private Collider others;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightCollider" || other.tag == "DownCollider")
        {
            Debug.Log("Snap");
            CanSnap = true;
            others = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "RightCollider" || other.tag == "DownCollider")
        {
            Debug.Log("Exit");
            CanSnap = false;
            others = null;

            // 블록 떼기
            this.transform.SetParent(null);
        }
    }
    
    IEnumerator OnMouseDrag()
    {
        Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));

        while (Input.GetMouseButton(0))
        {
            Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            transform.position = curPosition;
            yield return null;
        }
    }

    /*
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    
    }
    */

    private void OnMouseUp()
    {
        // 스냅
        if(CanSnap == true)
        {
            MeshFilter mesh = GetComponent<MeshFilter>();
            //Debug.Log(mesh.mesh.name);

            Vector3 snap = Vector3.zero;

            if(mesh.mesh.name.Contains("002"))
            {

                if(others.tag == "DownCollider")
                {
                    Debug.Log("Down");
                    snap = new Vector3(1f, -1f, 0f);
                }
                else if(others.tag == "RightCollider")
                {
                    Debug.Log("Right");
                    snap = new Vector3(2, 0, 0);
                }
            }
            else
            {
                if (others.tag == "DownCollider")
                {
                    Debug.Log("Down");
                    snap = new Vector3(0.5f, -1f, 0f);
                }
                else if (others.tag == "RightCollider")
                {
                    Debug.Log("Right");
                    snap = new Vector3(1.5f, 0, 0);
                }
            }
            this.transform.position = others.transform.parent.transform.position + snap;

            // 블록 붙이기
            this.transform.SetParent(others.transform.parent.transform);
        }
        //CanSnap = false;
    }
}
