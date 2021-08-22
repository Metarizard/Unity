using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TwoCarSelectionScript : MonoBehaviour
{
    public static GameObject[] selectionOptions;
    public static int selectionIndex1 = 0;
    private GameObject selection1;
    public TMP_Text selectionText1;
    public static int selectionIndex2 = 1;
    private GameObject selection2;
    public TMP_Text selectionText2;
    private static string[] carNames = { "Camaro", "Fat Lambo", "Sport Golf", "Formula One", "Old Mustang", "Aerodynamical Mix" };

    // Start is called before the first frame update
    void Start()
    {
        selectionOptions = Resources.LoadAll<GameObject>("Cars");
        //Player 1
        selection1 = Instantiate(selectionOptions[selectionIndex1], transform.position, transform.rotation);
        selectionText1.text = carNames[selectionIndex1];
        //Player 2
        selection2 = Instantiate(selectionOptions[selectionIndex2], transform.position + 40 * Vector3.right, transform.rotation);
        selectionText2.text = carNames[selectionIndex2];
    }

    void SpawnSelection1()
    {
       Destroy(selection1);
       selection1 = Instantiate(selectionOptions[selectionIndex1], transform.position ,transform.rotation);
       selectionText1.text = carNames[selectionIndex1];
    }

    void SpawnSelection2()
    {
        Destroy(selection2);
        selection2 = Instantiate(selectionOptions[selectionIndex2], transform.position + 40 * Vector3.right, transform.rotation);
        selectionText2.text = carNames[selectionIndex2];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectionIndex1 -= 1;
            if(selectionIndex1 < 0)
            {
                selectionIndex1 += selectionOptions.Length;
            }
            SpawnSelection1();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            selectionIndex1 += 1;
            if(selectionIndex1 == selectionOptions.Length)
            {
                selectionIndex1 -= selectionOptions.Length;
            }
            SpawnSelection1();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectionIndex2 -= 1;
            if (selectionIndex2 < 0)
            {
                selectionIndex2 += selectionOptions.Length;
            }
            SpawnSelection2();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectionIndex2 += 1;
            if (selectionIndex2 == selectionOptions.Length)
            {
                selectionIndex2 -= selectionOptions.Length;
            }
            SpawnSelection2();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(selection1);
            Destroy(selection2);
            CircuitMenu();
        }
    }

    public void CircuitMenu()
    {
        SceneManager.LoadScene(3);
    }
}
