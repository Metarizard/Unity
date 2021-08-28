using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float CurrentLapTime { get; private set; } = 0;
    public float LastLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;

    private float lapTimer;
    private int lastCheckpoint = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;
    private Car car;

    private void Awake()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        car = GetComponent<Car>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartLap()
    {
        CurrentLap++;
        lastCheckpoint = 1;
        lapTimer = Time.time;
    }

   void EndLap()
    {
        LastLapTime = Time.time - lapTimer;
        BestLapTime = Mathf.Min(BestLapTime, LastLapTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != checkpointLayer)
        {
            return;
        }
        if(other.gameObject.name == "1")
        {
            if(lastCheckpoint == checkpointCount)
            {
                EndLap();
            }
            if(CurrentLap == 0 || lastCheckpoint == checkpointCount)
            {
                StartLap();
            }
        }
        if(other.gameObject.name == (lastCheckpoint + 1).ToString())
        {
            lastCheckpoint++;
        }
    }
    // Update is called once per frame
    void Update()
    {

        CurrentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;
        car.Steer = GameManager.Instance.InputController.SteerInput;
        car.Throttle = GameManager.Instance.InputController.ThrottleInput;
        car.Brake = GameManager.Instance.InputController.BrakeInput;

    }
}
