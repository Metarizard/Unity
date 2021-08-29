using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public string inputSteerAxis;
    public string inputThrottleAxis;
    public string inputBrakeButton;
    public string inputRespawnButton;

    public bool RespawnInput { get; private set; }
    
    public float ThrottleInput { get; private set; }

    public float SteerInput { get; private set; }

    public float BrakeInput { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteerInput = Input.GetAxis(inputSteerAxis);
        ThrottleInput = Input.GetAxis(inputThrottleAxis);
        BrakeInput = Input.GetAxis(inputBrakeButton);
        RespawnInput = Input.GetButton(inputRespawnButton);
    }
}
