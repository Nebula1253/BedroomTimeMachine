using System;
using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private Outline[] outlines;

    // protected string displayText;
    public string displayText;

    protected bool isInteractable;
    public abstract void Interaction();

    public virtual void DisableInteraction() {
        isInteractable = false;
    }

    public virtual void EnableInteraction() {
        isInteractable = true;
    }

    public string GetDisplayText() {
        return displayText;
    }

    public void Highlight() {
        outlines = GetComponentsInChildren<Outline>();
        foreach (var outline in outlines)
        {
            outline.color = 1;
        }
    }

    public void UnHighlight() {
        foreach (var outline in outlines)
        {
            outline.color = 0;
        }
    }
}
