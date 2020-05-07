using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMenuManager : MonoBehaviour
{
    public static GameManager instance;
    GameState gameState;

    public enum GameState
    {
        StartMenu,
        InGame
    };

    private void Awake()
    {
        //instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetGameState(GameState.StartMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStartButton()
    {
        // SetLeftController();

        GameObject.Find("StartCanvas").SetActive(false);

        GameObject.Find("PopupUI").transform.Find("StartCanvasUI").gameObject.SetActive(true);
        GameObject.Find("PopupUI").transform.Find("StartCanvasUI").SetParent(GameObject.Find("[CameraRig]").transform.Find("Camera").transform);
        GameObject.Find("[CameraRig]").transform.Find("Camera").transform.Find("StartCanvasUI").localPosition = new Vector3(0, -0.5f, 2.5f);
        GameObject.Find("[CameraRig]").transform.Find("Camera").transform.Find("StartCanvasUI").localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        SetGameState(GameState.InGame);
    }

    public void TeleportPlayer()
    {
        //Transform cameraRigTransform = GameObject.Find("[CameraRig]").transform;
        //Transform golem = GameObject.Find("Golem").transform;

        //cameraRigTransform.position = new Vector3(golem.position.x, golem.position.y - 1f, golem.position.z + 1.25f);
    }


    public void DisableLeftController()
    {
        GameObject.Find("Controller (left)").GetComponent<LaserPoint>().enabled = false;
        GameObject.Find("Controller (left)").GetComponent<GrabBlock>().enabled = false;
    }
    
    public void SetLeftController()
    {
        GameObject.Find("Controller (left)").GetComponent<LaserPoint>().enabled = true;
        GameObject.Find("Controller (left)").GetComponent<GrabBlock>().enabled = true;
    }

    void SetGameState(GameState newState)
    {
        this.gameState = newState;
    }

    void CheckInput(GameState inState)
    {
        if(inState != GameState.InGame)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {

        }
    }

    public void MagicCircleRender()
    {
        GameObject.Find("Golem").transform.Find("WorkUICanvas").gameObject.SetActive(true);
        GameObject.Find("Golem").transform.Find("MagicButton").gameObject.SetActive(false);
    }

    public void MagicCircleClose()
    {
        GameObject.Find("Golem").transform.Find("WorkUICanvas").gameObject.SetActive(false);
        GameObject.Find("Golem").transform.Find("MagicButton").gameObject.SetActive(true);
    }
}
