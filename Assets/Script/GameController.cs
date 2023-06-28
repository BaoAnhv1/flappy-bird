using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isEndGame = false;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                //Time.timeScale = 1;
                //isEndGame = false;
                //load man choi
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        }
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

   void StartGame()
    {
        Debug.Log("start game");
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        StartGame();
    }
    public void EndGame()
    {
        Debug.Log("EndGame bird controller");
        isEndGame = true;
        isStartFirstTime = false; ;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your point\n" + gamePoint.ToString();
    }
}
