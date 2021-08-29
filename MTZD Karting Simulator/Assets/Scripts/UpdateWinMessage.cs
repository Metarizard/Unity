using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UpdateWinMessage : MonoBehaviour
{
    public TMP_Text winText;

    
    // Start is called before the first frame update
    void Start()
    {
        winText.text = UIController.WinnerText;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(MenuManager.Instance);
            SceneManager.LoadScene(0);
        }
    }
}
