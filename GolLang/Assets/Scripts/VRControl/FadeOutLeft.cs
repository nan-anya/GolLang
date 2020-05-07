using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutLeft : MonoBehaviour
{
    private float speed = 2f;
    float time = 0;
    float fadeTime = 0.2f;

    CanvasRenderer[] CanvasList;

    // Start is called before the first frame update
    void Start()
    {
        CanvasList = GetComponentsInChildren<CanvasRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time < fadeTime)
        {
            GetComponent<CanvasRenderer>().SetAlpha(1f - time / fadeTime);
            foreach(CanvasRenderer cr in CanvasList )
            {
                cr.SetAlpha(1f - time / fadeTime);
            }
        }
        else
        {
            time = 0;

            GetComponent<FadeOutLeft>().enabled = false;
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SETA()
    {
        GetComponent<FadeOutLeft>().enabled = true;
    }
}