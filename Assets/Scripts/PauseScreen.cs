using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Button resumeButton, quitButton;

    // Start is called before the first frame update
    void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Application.Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Resume() {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);

        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().MovementLocked = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().EnableInventoryPrompt();
        Cursor.lockState = CursorLockMode.Locked;
    }

}
