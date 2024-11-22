using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    public Material newMaterial; // The new material to swap to
    public float transitionDuration = 2f; // Duration of the transition

    private Renderer objectRenderer;
    private bool isSwapping = false;

    private void Start()
    {
        // Get the Renderer component of the GameObject
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("No Renderer found on this GameObject! Make sure this script is attached to a GameObject with a Renderer.");
        }
        else
        {
            Debug.Log("Renderer found. Initial material set to: " + objectRenderer.material.name);
        }
    }

    private void Update()
    {


        // Check for spacebar press and start swapping if not already in progress
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed.");
            if (!isSwapping)
            {
                if (newMaterial == null)
                {
                    Debug.LogError("No newMaterial assigned in the Inspector! Please assign a material.");
                    return;
                }

                Debug.Log("Starting material transition.");
                StartCoroutine(SwapToNewMaterial(newMaterial));
            }
            else
            {
                Debug.Log("Material swap already in progress.");
            }
        }
    }

    private IEnumerator SwapToNewMaterial(Material targetMaterial)
    {
        isSwapping = true;

        // Create a temporary material for blending
        Material currentMaterial = objectRenderer.material;
        Material tempMaterial = new Material(currentMaterial);
        objectRenderer.material = tempMaterial;

        Debug.Log("Temporary material created for blending: " + tempMaterial.name);

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);

            // Debugging blend factor
            Debug.Log("Blending: t = " + t);

            // Interpolate properties (like color) from current material to new material
            tempMaterial.Lerp(currentMaterial, targetMaterial, t);

            yield return null;
        }

        // Set the final material
        objectRenderer.material = targetMaterial;
        Debug.Log("Material transition complete. Final material set to: " + targetMaterial.name);

        isSwapping = false;
    }

}
