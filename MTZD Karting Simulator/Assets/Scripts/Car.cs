using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;

    public float motorTorque = 1500.0f;
    public float maxSteer = 20.0f;
  
    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody rB;
    private Wheel[] wheels;


    // Start is called before the first frame update
    void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        rB = GetComponent<Rigidbody>();
        rB.centerOfMass = centerOfMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        Steer = GameManager.Instance.InputController.SteerInput;
        Throttle = GameManager.Instance.InputController.ThrottleInput;
        Debug.Log(Throttle);
        foreach(var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}
