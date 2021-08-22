using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offsetOut = new Vector3(0.0f, 2.4f, -3.25f);
    private Vector3 offsetIn = new Vector3(0.0f, 0.0f, 0.0f);
    private Quaternion cameraRotation = Quaternion.Euler(30, 0, 0);
    private bool view = false;
    private KeyCode toggleKey = KeyCode.Tab;

    void ChangeView()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (view)
            {
                view = false;
            }
            else
            {
                view = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ChangeView();

        if (view)
        {
            transform.position = player.transform.position + offsetIn;
            transform.eulerAngles = new Vector3(player.transform.eulerAngles.x + 30.0f, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
        }
        else
        {
            transform.position = player.transform.position + offsetOut;
            transform.eulerAngles = new Vector3(player.transform.eulerAngles.x + 30.0f, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
        }
    }
}
