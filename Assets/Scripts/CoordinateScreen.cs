using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;


public class CoordinateScreen : MonoBehaviour
{
    public TMP_Text errorDisplay;
    private TMP_InputField inputField;
    private Button submitButton;
    private FlightController flightController;
    private GameObject player;
    public Color valid, invalid;

    void Awake() {
        inputField = GetComponentInChildren<TMP_InputField>();
        submitButton = GetComponentInChildren<Button>();
        flightController = FlightController.Instance;

        submitButton.onClick.AddListener(ValidateCoordinates);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            player.GetComponent<Player>().EnableInventoryPrompt();
            player.GetComponent<FirstPersonController>().MovementLocked = false;

            Cursor.lockState = CursorLockMode.Locked;

            errorDisplay.text = "";
            gameObject.SetActive(false);
        }
    }

    void ValidateCoordinates() {
        if (flightController.SetCoordinates(inputField.text)) {
            errorDisplay.color = valid;
            errorDisplay.text = "SUCCESS!";
        }
        else {
            inputField.text = "";
            errorDisplay.color = invalid;
            errorDisplay.text = "INVALID COORDINATES - TRY AGAIN";
        }
    }
}
