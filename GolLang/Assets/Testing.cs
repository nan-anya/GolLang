using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject golem;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 gVect = golem.transform.position;
        Vector3 pVect = player.transform.position;

        Vector3 dir = golem.transform.forward * -1;
        Vector3 pos = gVect + dir * 3;

        player.transform.position = pos;
        player.transform.LookAt(golem.transform);

        Debug.Log("GOLEM : " + gVect);
        Debug.Log("PLAYER : " + pVect);
        Debug.Log("Back : " + golem.transform.forward * -1);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
