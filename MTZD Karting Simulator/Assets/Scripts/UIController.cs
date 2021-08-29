using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public TMP_Text lap;
    public TMP_Text time;
    public TMP_Text best;
    public TMP_Text last;

    public static string WinnerText { get; private set; }
    private Player carPlayer;
    private Player[] carPlayers = new Player[2];
    private int currentLap;
    private int currentLap2;
    private float bestLapTime;
    private float currentLapTime;
    private float lastLapTime;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.singlePlayer)
        {
            carPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        else if (GameManager.twoPlayers)
        {
            carPlayers[0] = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
            carPlayers[1] = GameObject.FindGameObjectsWithTag("Player")[1].GetComponent<Player>();
            lap.text = $"Lap: 0/3";
            last.text = $"Lap: 0/3";

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.singlePlayer)
        {
            if (carPlayer == null)
            {
                return;
            }

            if (carPlayer.CurrentLap != currentLap)
            {
                currentLap = carPlayer.CurrentLap;
                lap.text = "Lap: " + currentLap;
            }

            if (carPlayer.CurrentLapTime != currentLapTime)
            {
                currentLapTime = carPlayer.CurrentLapTime;
                time.text = $"Time: {(int)currentLapTime / 60}:{(currentLapTime) % 60:00.00}"; //Trick with the $ sign!
            }

            if (carPlayer.BestLapTime != bestLapTime)
            {
                bestLapTime = carPlayer.BestLapTime;
                best.text = bestLapTime < 1000000 ? $"Best: {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.00}" : "Best: NONE"; //Trick with the $ sign!
            }

            if (carPlayer.LastLapTime != lastLapTime)
            {
                lastLapTime = carPlayer.LastLapTime;
                last.text = $"Last: {(int)lastLapTime / 60}:{(lastLapTime) % 60:00.00}"; //Trick with the $ sign!
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(GameObject.FindWithTag("Player"));
                Destroy(MenuManager.Instance);
                SceneManager.LoadScene(0);
            }
        }
        else if (GameManager.twoPlayers)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(GameObject.FindWithTag("Player"));
                Destroy(GameObject.FindWithTag("Player"));
                Destroy(MenuManager.Instance);
                SceneManager.LoadScene(0);
            }

            if (carPlayers == null)
            {
                return;
            }

            if (carPlayers[0].CurrentLap == 4)
            {
                Destroy(GameObject.FindWithTag("Player"));
                Destroy(GameObject.FindWithTag("Player"));
                WinnerText = "Player 1 wins! Congrats on being the best driver!";
                SceneManager.LoadScene(4);
            }

            if(carPlayers[1].CurrentLap == 4)
            {
                Destroy(GameObject.FindWithTag("Player"));
                Destroy(GameObject.FindWithTag("Player"));
                WinnerText = "Player 2 wins! Congrats on being the best driver!";
                SceneManager.LoadScene(4);
            }

            if (carPlayers[0].CurrentLap != currentLap)
            {
                currentLap = carPlayers[0].CurrentLap;
                lap.text = $"Lap: {currentLap}/3";
            }

            if (carPlayers[1].CurrentLap != currentLap2)
            {
                currentLap2 = carPlayers[1].CurrentLap;
                last.text = $"Lap: {currentLap2}/3";
            }

            if(carPlayers[0].CurrentLap > carPlayers[1].CurrentLap)
            {
                time.text = $"Position: 1";
                best.text = $"Position: 2";
            }
            else if(carPlayers[1].CurrentLap > carPlayers[0].CurrentLap)
            {
                time.text = $"Position: 2";
                best.text = $"Position: 1";
            }
            else
            {
                if(carPlayers[0].lastCheckpoint > carPlayers[1].lastCheckpoint)
                {
                    time.text = $"Position: 1";
                    best.text = $"Position: 2";
                }
                else if (carPlayers[1].lastCheckpoint > carPlayers[0].lastCheckpoint)
                {
                    time.text = $"Position: 2";
                    best.text = $"Position: 1";
                }
                else
                {
                    //If they are in the same checkpoint interval, then we check which player is ahead by relative position
                    if (Vector3.Dot(carPlayers[0].transform.forward, carPlayers[1].transform.position - carPlayers[0].transform.position) < 0)
                    {
                        time.text = $"Position: 1";
                        best.text = $"Position: 2";
                    }
                    else
                    {
                        best.text = $"Position: 1";
                        time.text = $"Position: 2";
                    }
                }
            }
        }
      

    }
}
