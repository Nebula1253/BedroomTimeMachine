using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button toInfo, quit, startGame, back;
    public GameObject startScreen, infoScreen;

    // Start is called before the first frame update
    void Start()
    {
        toInfo.onClick.AddListener(EnableInfoScreen);
        quit.onClick.AddListener(Application.Quit);
        startGame.onClick.AddListener(() => SceneManager.LoadScene(1));
        back.onClick.AddListener(DisableInfoScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnableInfoScreen() {
        startScreen.SetActive(false);
        infoScreen.SetActive(true);
    }

    private void DisableInfoScreen() {
        infoScreen.SetActive(false);
        startScreen.SetActive(true);
    }
}
