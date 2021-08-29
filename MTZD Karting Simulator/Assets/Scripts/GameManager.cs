using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool singlePlayer;
    public static bool twoPlayers;
    public static GameManager Instance { get; private set; }
    private static GameObject player;
    private static GameObject player1;
    private static GameObject player2;
    private static Vector3 initialPosition = new Vector3(29.25f, 1.5f, 0.4f);
    private GameObject[] prefabs;

    private void Awake()
    {
        prefabs = Resources.LoadAll<GameObject>("Prefabs");

        if (singlePlayer)
        {
            player = Instantiate(prefabs[SingleCarSelectionScript.selectionIndex],initialPosition,transform.rotation);
            player.GetComponentInChildren<InputController>().inputSteerAxis = "Horizontal";
            player.GetComponentInChildren<InputController>().inputThrottleAxis = "Vertical";
            player.GetComponentInChildren<InputController>().inputBrakeButton = "Stop";
            player.GetComponentInChildren<InputController>().inputRespawnButton = "Reset";

        }
        else if (twoPlayers)
        {
            player1 = Instantiate(prefabs[TwoCarSelectionScript.selectionIndex1], initialPosition + 2 * Vector3.left, transform.rotation);
            player2 = Instantiate(prefabs[TwoCarSelectionScript.selectionIndex2], initialPosition + 2 * Vector3.right, transform.rotation);
            player1.GetComponentInChildren<Camera>().rect = new Rect(-0.5f, 0.0f, 1.0f, 1.0f);
            player2.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0.0f, 1.0f, 1.0f);
            player1.GetComponentInChildren<InputController>().inputSteerAxis = "Horizontal2";
            player1.GetComponentInChildren<InputController>().inputThrottleAxis = "Vertical2";
            player1.GetComponentInChildren<InputController>().inputBrakeButton = "Stop2";
            player1.GetComponentInChildren<InputController>().inputRespawnButton = "Reset2";
            player2.GetComponentInChildren<InputController>().inputSteerAxis = "Horizontal";
            player2.GetComponentInChildren<InputController>().inputThrottleAxis = "Vertical";
            player2.GetComponentInChildren<InputController>().inputBrakeButton = "Stop";
            player2.GetComponentInChildren<InputController>().inputRespawnButton = "Reset";
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (GameObject.Find("AudioSource").GetComponent<AudioSource>().mute == true)
            {
                GameObject.Find("AudioSource").GetComponent<AudioSource>().mute = false;
            }
            else
            {
                GameObject.Find("AudioSource").GetComponent<AudioSource>().mute = true;

            }
        }

    }
}
