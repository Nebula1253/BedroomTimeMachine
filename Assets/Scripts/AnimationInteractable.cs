using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationInteractable : Interactable
{
    public string attributeName;
    public bool interact;
    public Animator animator;
    public string makeTrue, makeFalse, disabled;
    public AudioClip makeTrueAudio, makeFalseAudio;
    public float makeFalseAudioDelay;
    // Start is called before the first frame update
    void Start()
    {
        if (interact) {
            EnableInteraction();
        }
        else {
            DisableInteraction();
        }
        // animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interaction()
    {
        if (isInteractable) {
            // GetComponent<AudioSource>().Play();
            Debug.Log(animator.GetBool(attributeName));
            if (animator.GetBool(attributeName)) {
                animator.SetBool(attributeName, false);

                GetComponent<AudioSource>().clip = makeFalseAudio;
                GetComponent<AudioSource>().PlayDelayed(makeFalseAudioDelay);

                displayText = makeTrue;
            }
            else {
                animator.SetBool(attributeName, true);

                GetComponent<AudioSource>().clip = makeTrueAudio;
                GetComponent<AudioSource>().Play();

                displayText = makeFalse;
            }
        }
    }

    public override void DisableInteraction()
    {
        base.DisableInteraction();
        displayText = disabled;
    }

    public override void EnableInteraction()
    {
        base.EnableInteraction();
        if (animator.GetBool(attributeName)) {
            displayText = makeFalse;
        }
        else {
            displayText = makeTrue;
        }
    }
}
