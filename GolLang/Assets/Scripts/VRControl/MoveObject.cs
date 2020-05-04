using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private bool CanSnap;
    private Collider others;
    private float BlockScales;
    //private float ScaleRatio = 0.02f;
    private float ScaleRatio = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RightCollider" || other.tag == "DownCollider")
        {
            Debug.Log("In " + other.tag);
            CanSnap = true;
            others = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "RightCollider" || other.tag == "DownCollider")
        {
            Debug.Log("Exit " + other.tag);
            CanSnap = false;
            others = null;
          
            // 블록 떼기
            this.transform.SetParent(GameObject.Find("WorkSpace").transform);
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

     // 블록 합치기 / VR 환경
    public void CheckReleased()
    {
        if (CanSnap && others != null)
        {
            // 스냅
            if (CanSnap == true)
            {
                MeshFilter mesh = GetComponent<MeshFilter>();
                Vector3 snap = Vector3.zero;

                // 긴 블록
                if (mesh.mesh.name.Contains("002") || mesh.mesh.name.Contains("001"))
                {
                    if (others.tag == "DownCollider")
                    {
                        Debug.Log("Down");
                        snap = new Vector3(0.5f, -0.5f, 0f);
                    }
                    else if (others.tag == "RightCollider")
                    {
                        Debug.Log("Right");
                        snap = new Vector3(1f, 0, 0);
                    }
                }

                Debug.Log("SNAP");

                // 위치 계산
                BoxCollider boxCollider = others.transform.parent.GetComponent<BoxCollider>();
                BlockScales = ((this.GetComponent<BoxCollider>().size.x - 1.3f) / 2) + ((boxCollider.size.x - 1.3f) / 2);
                BlockScales *= ScaleRatio;

                // 블록 붙이기
                this.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                this.transform.localPosition = others.transform.parent.transform.localPosition + (snap * BlockScales);
                this.transform.SetParent(others.transform);
            }
        }
    }

     // 블록 합치기 / 드래그
    private void OnMouseUp()
    {
        // 스냅
        if(CanSnap == true)
        {
            MeshFilter mesh = GetComponent<MeshFilter>();
            Vector3 snap = Vector3.zero;

            // 긴 블록
            if(mesh.mesh.name.Contains("002") || mesh.mesh.name.Contains("001"))
            {
                if(others.tag == "DownCollider")
                {
                    Debug.Log("Down");
                    snap = new Vector3(0.5f, -0.5f, 0f);
                }
                else if(others.tag == "RightCollider")
                {
                    Debug.Log("Right");
                    snap = new Vector3(1f, 0, 0);
                }
            }

            Debug.Log("SNAP");

            // 위치 계산
            BoxCollider boxCollider = others.transform.parent.GetComponent<BoxCollider>();
            BlockScales = ((this.GetComponent<BoxCollider>().size.x - 1.3f) / 2) + ((boxCollider.size.x - 1.3f) / 2);
            BlockScales *= ScaleRatio;

            // 블록 붙이기
            this.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
            this.transform.localPosition = others.transform.parent.transform.localPosition + (snap * BlockScales);  
            this.transform.SetParent(others.transform);
            others = null;
        }
    }
}