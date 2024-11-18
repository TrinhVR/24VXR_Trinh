using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghtOff : MonoBehaviour
{
    [SerializeField]
    private GameObject pointLight;

    private bool isLightActive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the Point Light GameObject starts off
        if (pointLight != null)
        {
            pointLight.SetActive(true);
        }
        else
        {
            Debug.LogError("PointLight GameObject is not assigned!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the lever
        if (other.CompareTag("Lever") && !isLightActive)
        {
            // Activate the Point Light GameObject
            if (pointLight != null)
            {
                pointLight.SetActive(false);
                isLightActive = false;
                Debug.Log("Point Light deactivated!");
            }
        }
    }

}
