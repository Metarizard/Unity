using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject UIPanel;

    public TMP_Text lap;
    public TMP_Text time;
    public TMP_Text best;
    public TMP_Text last;

    public Player carPlayer;
    private int currentLap;
    private float bestLapTime;
    private float currentLapTime;
    private float lastLapTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carPlayer == null){
            return;
        }
        
        if(carPlayer.CurrentLap != currentLap){
            currentLap = carPlayer.CurrentLap;
            lap.text = "Lap: " + currentLap;
        }

        if(carPlayer.CurrentLapTime != currentLapTime)
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

    }
}
