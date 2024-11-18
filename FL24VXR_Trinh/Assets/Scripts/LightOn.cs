using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    [SerializeField]
    private GameObject pointLight;

    private bool isLightActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the Point Light GameObject starts off
        if (pointLight != null)
        {
            pointLight.SetActive(false);
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
                pointLight.SetActive(true);
                isLightActive = true;
                Debug.Log("Point Light activated!");
            }
        }
    }


}
