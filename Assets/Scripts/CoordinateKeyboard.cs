using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CoordinateKeyboard : Interactable
{
    public GameObject coordinatesUI;
    private GameObject player;
    void Awake()
    {
        // displayText = "Set Time-Space Coordinates";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction() {
        if (isInteractable) {
            GetComponent<AudioSource>().Play();
            coordinatesUI.SetActive(true);

            player.GetComponent<Player>().HideInventoryPrompt();
            player.GetComponent<FirstPersonController>().MovementLocked = true;

            Cursor.lockState = CursorLockMode.None;
        }
    }

    public override void DisableInteraction()
    {
        base.DisableInteraction();
        displayText = "Can't Set Coordinates - Not In Flight";
    }

    public override void EnableInteraction()
    {
        base.EnableInteraction();
        displayText = "Set Time-Space Coordinates";
    }
}
