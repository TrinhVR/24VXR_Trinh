using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogWarning("No Renderer Component found");
        }
    }
    [ContextMenu("ChangeColor")]
    public void colorChanger()
    {
        if (objectRenderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            objectRenderer.material.color = randomColor;
        }
        else
        {
            Debug.LogWarning("No Renderer Component found");
        }
    }

}
