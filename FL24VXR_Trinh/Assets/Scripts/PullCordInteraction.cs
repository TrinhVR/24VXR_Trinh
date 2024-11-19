using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PullCordInteraction : XRBaseInteractor
{
    [Header("Pull Cord Events")]
    public UnityEvent onGrab;    // Event triggered when the cord is grabbed
    public UnityEvent onRelease; // Event triggered when the cord is released

    // Called when the cord is grabbed
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args); // Call the base functionality of XRGrabInteractable

        // Trigger the onGrab Unity Eventbn 
    }

    // Called when the cord is released
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args); // Call the base functionality of XRGrabInteractable

        // Trigger the onRelease Unity Event
        if (onRelease != null)
        {
            onRelease.Invoke();
        }
    }
}
