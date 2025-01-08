using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DematLever : Interactable
{
    public Animator animator, columnAnimator;
    private FlightController flightController;

    void Start()
    {
        displayText = "Take Off";
        isInteractable = true;

        flightController = FlightController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interaction()
    {
        if (isInteractable) {
            GetComponent<AudioSource>().Play();
            if (animator.GetBool("ConsoleActive")) {
                animator.SetBool("ConsoleActive", false);
                columnAnimator.SetBool("ConsoleActive", false);
                
                flightController.Landing();
            }
            else {
                animator.SetBool("ConsoleActive", true);
                columnAnimator.SetBool("ConsoleActive", true);

                flightController.InFlight();
            }
        }
    }

    public override void DisableInteraction()
    {
        base.DisableInteraction();
        displayText = "Can't Land - Coordinates Not Set";
    }
}
