using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static MenuManager Instance;

    private GameObject titleScreen;
    public GameObject mainMenuScreen;

    void Start()
    {
        titleScreen = GameObject.Find("TitleScreen");
        titleScreen.SetActive(true);
        mainMenuScreen = GameObject.Find("MainMenuScreen");
        mainMenuScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(titleScreen != null)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) && (titleScreen.activeInHierarchy))
            {
                titleScreen.SetActive(false);
                mainMenuScreen.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
#if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SinglePlayer()
    {
        GameManager.singlePlayer = true;
        GameManager.twoPlayers = false;
        SceneManager.LoadScene(1);
    }

    public void TwoPlayers()
    {
        GameManager.twoPlayers = true;
        GameManager.singlePlayer = false;
        SceneManager.LoadScene(2);
    }
}
