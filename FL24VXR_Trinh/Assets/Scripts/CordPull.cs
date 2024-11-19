using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordPull : MonoBehaviour
{
    public ConfigurableJoint pullCordJoint; // The Configurable Joint attached to the pull cord
    public GameObject sceneLight;          // The light GameObject to toggle
    public float pullThreshold = 0.5f;     // The distance threshold to detect a pull

    private Vector3 initialPosition;       // The initial position of the cord
    private bool lightState = false;       // Tracks the light's active/inactive state
    private bool isCordGrabbed = false;    // Tracks whether the cord is actively being grabbed
    private bool hasToggled = false;       // Prevents multiple toggles during a single pull

    void Start()
    {
        if (pullCordJoint == null)
        {
            Debug.LogError("Assign a Configurable Joint to the pullCordJoint variable.");
        }

        if (sceneLight == null)
        {
            Debug.LogError("Assign a Light GameObject to the sceneLight variable.");
        }

        // Store the initial position of the cord
        initialPosition = pullCordJoint.transform.localPosition;
    }

    void Update()
    {
        if (!isCordGrabbed)
        {
            // Do nothing if the cord is not being grabbed
            return;
        }

        // Calculate the current pull distance along the local Z-axis
        float pullDistance = Mathf.Abs(pullCordJoint.transform.localPosition.y - initialPosition.y);

        // Toggle the light state when the cord is pulled beyond the threshold
        if (pullDistance > pullThreshold && !hasToggled)
        {
            hasToggled = true; // Prevent multiple toggles during the same pull

            // Toggle the light's active state
            lightState = !lightState;
            sceneLight.SetActive(lightState);
            Debug.Log("Light toggled " + (lightState ? "ON" : "OFF"));
        }

        // Reset toggle flag when the cord returns close to the initial position
        if (pullDistance < pullThreshold / 2f)
        {
            hasToggled = false;
        }
    }

    // Call this method when the user grabs the cord (e.g., from an interaction script)
    public void OnCordGrabbed()
    {
        isCordGrabbed = true;
    }

    // Call this method when the user releases the cord (e.g., from an interaction script)
    public void OnCordReleased()
    {
        isCordGrabbed = false;
    }

}
