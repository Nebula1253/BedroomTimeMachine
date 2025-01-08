using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player : MonoBehaviour
{
    private Transform cameraTransform;
    private RaycastHit hitInfo;
    public TMP_Text display;
    private Interactable prevInteractable;
    public GameObject inventoryUI, inventoryPromptUI, pausePromptUI;
    public bool inventoryAvailable = false;
    public Color textHighlightColor;
    public GameObject pauseScreen;
    private string colorCode;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        colorCode = ColorUtility.ToHtmlStringRGBA(textHighlightColor);
        Debug.Log(colorCode);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var movement = gameObject.GetComponent<FirstPersonController>();
        
        if (!movement.MovementLocked) {
            if (Input.GetKeyDown(KeyCode.I)) {
                movement.MovementLocked = true;
                inventoryUI.SetActive(true);

                HideInventoryPrompt();
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                movement.MovementLocked = true;
                Time.timeScale = 0.0f;
                pauseScreen.SetActive(true);

                HideInventoryPrompt();

                Cursor.lockState = CursorLockMode.None;
            }
        }
        

        if (!movement.MovementLocked && Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitInfo, 100.0f)) {
            Interactable interactable = hitInfo.collider.gameObject.GetComponent<Interactable>();

            if (interactable != null) {
                ClearPrevInteractable();
                
                prevInteractable = interactable;
                interactable.Highlight();
                display.text = "<font=\"LiberationSans SDF\">" + "<mark=#" + colorCode + ">" + interactable.GetDisplayText() + "</mark>";

                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    interactable.Interaction();
                }
            }
            else {
                ClearPrevInteractable();
            }
        }
        else {
            ClearPrevInteractable();
        }
    }

    private void ClearPrevInteractable() {
        if (prevInteractable != null) {
            prevInteractable.UnHighlight();
            display.text = "";
            prevInteractable = null;
        } 
    }

    public void EnableInventoryPrompt() {
        inventoryPromptUI.SetActive(true);
        pausePromptUI.SetActive(true);
    }

    public void HideInventoryPrompt() {
        inventoryPromptUI.SetActive(false);
        pausePromptUI.SetActive(false);
    }

    public void ClearDisplayText() {
        display.text = "";
    }
}
