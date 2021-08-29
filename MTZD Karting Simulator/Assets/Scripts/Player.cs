using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float CurrentLapTime { get; private set; } = 0;
    public float LastLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;

    public InputController InputController { get; private set; }

    private float lapTimer;
    public int lastCheckpoint = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;
    private Car car;
    private Vector3[] checkpointPosition;
    private Quaternion[] checkpointRotation;

    private void Awake()
    {
        InputController = GetComponentInChildren<InputController>();
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointPosition = new Vector3[checkpointCount];
        checkpointRotation = new Quaternion[checkpointCount];

        for (int i = 0; i < checkpointCount; i++)
        {
            checkpointPosition[i] = checkpointsParent.GetChild(i).position;
            checkpointRotation[i] = checkpointsParent.GetChild(i).rotation;

        }
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
        car.Steer = this.InputController.SteerInput;
        car.Throttle = this.InputController.ThrottleInput;
        car.Brake = this.InputController.BrakeInput;
        if (this.InputController.RespawnInput)
        {
            if(lastCheckpoint != 0)
            {
                transform.position = checkpointPosition[lastCheckpoint - 1] + 2*Vector3.down; //Update position to last checkpoint (-1 because of indexing differences)!
                transform.rotation = checkpointRotation[lastCheckpoint - 1];
            }
        }
    }
}
