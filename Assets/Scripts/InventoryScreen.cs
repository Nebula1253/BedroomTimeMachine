using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InventoryScreen : MonoBehaviour
{
    private GameObject player;
    public GameObject[] noteImages;
    public static InventoryScreen Instance { get; private set; }

    public InventoryScreen() {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            player.GetComponent<Player>().EnableInventoryPrompt();
            player.GetComponent<FirstPersonController>().MovementLocked = false;

            Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
        }
    }

    public void EnableImage(int whichNote) {
        noteImages[whichNote].SetActive(true);
    }
}
