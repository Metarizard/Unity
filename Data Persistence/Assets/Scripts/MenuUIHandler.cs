using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;

    private void Start()
    {
        HighScoreText.text = $"High Score: " + MenuManager.Instance.HighScore + " by: " + MenuManager.Instance.PlayerName;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void CurrentPlayerName()
    {
        MenuManager.Instance.CurrentPlayer = this.transform.Find("Container").gameObject.transform.Find("PlayerNameInput").gameObject.GetComponent<TMP_InputField>().text; ;
    }
}