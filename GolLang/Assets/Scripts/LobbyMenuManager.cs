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
        DisableLeftController();

        GameObject.Find("StartCanvas").SetActive(false);

        SetGameState(GameState.InGame);
    }

    void DisableLeftController()
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
