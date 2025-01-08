using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Interactable
{
    public AudioClip clip;
    public int whichNote;
    // Start is called before the first frame update
    void Start()
    {
        displayText = "Pick Up Note";
        isInteractable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {
        if (isInteractable) {
            var playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            playerScript.ClearDisplayText();
            InventoryScreen.Instance.EnableImage(whichNote);

            AudioSource.PlayClipAtPoint(clip, transform.position, 0.6f);
            gameObject.SetActive(false);
        }
    }
}
