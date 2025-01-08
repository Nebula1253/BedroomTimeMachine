using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    private bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        isInteractable = true;
        displayText = "Turn Off Lights";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {
        if (isInteractable) {
            GetComponent<AudioSource>().Play();
            Tubelight.Instance.SetLight();

            on = on ? false : true;
            displayText = on ? "Turn Off Lights" : "Turn On Lights";
        }
    }
}
