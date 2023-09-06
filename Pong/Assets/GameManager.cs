using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerScore1 = 0;
    public int PlayerScore2 = 0;

    public GUISkin layout;
    private GameObject theBall;
    private GameObject secondBall;
    private bool isSecondBallActive = false;
    private AudioSource audioSource2;

    private void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Tag Ball");
        secondBall = GameObject.FindGameObjectWithTag("SecondBall");
        audioSource2 = GetComponent<AudioSource>();
        InitializeSecondBall(); // Inicializa a segunda bola no início
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            RestartBalls(); // Reinicie ambas as bolas quando "RESTART" for pressionado
        }

        if (!isSecondBallActive)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 90, 120, 53), "Bola 2 OFF"))
            {
                isSecondBallActive = true;
                secondBall.SendMessage("StartBalls"); // Inicie a segunda bola
                secondBall.SetActive(true); // Ative a segunda bola
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 90, 120, 53), "Bola 2 ON"))
            {
                isSecondBallActive = false;
                secondBall.SendMessage("ResetBall"); // Reinicie a segunda bola
                secondBall.SetActive(false); // Desative a segunda bola
            }
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            RestartBalls(); // Reinicie ambas as bolas quando um jogador vencer
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            RestartBalls(); // Reinicie ambas as bolas quando um jogador vencer
        }
    }

    public void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
            audioSource2.Play();
        }
        else
        {
            PlayerScore2++;
            audioSource2.Play();
        }
    }

    private void InitializeSecondBall()
    {
        if (secondBall == null)
        {
            secondBall = GameObject.FindGameObjectWithTag("SecondBall");
        }

        if (secondBall != null)
        {
            secondBall.SendMessage("StartBalls"); // Inicie a segunda bola
            secondBall.SetActive(false); // Desative a segunda bola no início
        }
    }

    private void RestartBalls()
    {
        if (theBall != null)
        {
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (secondBall != null)
        {
            secondBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }
}
