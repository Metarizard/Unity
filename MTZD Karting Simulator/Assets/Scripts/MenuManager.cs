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
        SceneManager.LoadScene(1);
    }

    public void TwoPlayers()
    {
        SceneManager.LoadScene(2);
    }
}
