using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SingleCarSelectionScript : MonoBehaviour
{
    public static bool singlePlayer;
    private static GameObject[] selectionOptions;
    private static GameObject[] prefabs;
    public static int selectionIndex = 2;
    private GameObject selection;
    public TMP_Text selectionText;
    private static string[] carNames = { "Camaro", "Fat Lambo", "Sport Golf", "Formula One", "Old Mustang", "Aerodynamical Mix" };

    // Start is called before the first frame update
    void Start()
    {
        prefabs = Resources.LoadAll<GameObject>("prefabs");
        selectionOptions = Resources.LoadAll<GameObject>("Cars");
        selection = Instantiate(selectionOptions[selectionIndex], transform.position, transform.rotation);
        selectionText.text = carNames[selectionIndex];
    }
    
    void SpawnSelection()
    {
       Destroy(selection);
       selection = Instantiate(selectionOptions[selectionIndex], transform.position,transform.rotation);
       selectionText.text = carNames[selectionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectionIndex -= 1;
            if(selectionIndex < 0)
            {
                selectionIndex += selectionOptions.Length;
            }
            SpawnSelection();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectionIndex += 1;
            if(selectionIndex == selectionOptions.Length)
            {
                selectionIndex -= selectionOptions.Length;
            }
            SpawnSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(selection);
            Circuit();
        }
    }

    public void Circuit()
    {
        SceneManager.LoadScene(3);
    }
}
