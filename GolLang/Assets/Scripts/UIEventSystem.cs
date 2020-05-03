using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventSystem : MonoBehaviour
{
    public float FadeTime = 1f;

    public GameObject nextCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        Debug.Log("Fade In");
    }

    IEnumerator fadeoutplay()
    {

        yield return null;
    }
}