using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private static float offsetOutZ = -3.25f;
    [SerializeField] private static float offsetOutY = 2.4f;
    private Vector2 orbitAngles = new Vector2(30.0f, 0.0f);
    private Vector3 offsetOut = new Vector3(0.0f, offsetOutY, offsetOutZ);
    private Vector3 offsetIn = new Vector3(0.0f, 2.0f, 0.0f);
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

    private void Awake()
    {
        transform.localRotation = Quaternion.Euler(orbitAngles);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void ConstrainAngles() 
    { 
        if(orbitAngles.y < 0.0f)
        {
            orbitAngles.y += 360.0f;
        }
        else if(orbitAngles.y >= 360.0f)
        {
            orbitAngles.y -= 360.0f;
        }
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
            orbitAngles.y = player.transform.eulerAngles.y;
            ConstrainAngles();
            Quaternion lookRotation = Quaternion.Euler(orbitAngles);
            Vector3 lookDirection = lookRotation * Vector3.forward;
            Vector3 lookPosition = player.transform.position - lookDirection * Mathf.Sqrt(offsetOutY*offsetOutY + offsetOutZ*offsetOutZ);
            transform.SetPositionAndRotation(lookPosition, lookRotation);
        }
    }
}
