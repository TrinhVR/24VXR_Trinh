using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererComponent : MonoBehaviour
{
    // Renderer is responsible for how th object is drawn in the game, controlling properties like materials, textures, and visibility
    // Use it to manipulate how the object looks, interacts with light, and appears on the screen

    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectRenderer.material.color = Color.green; 
            //objectRenderer.enabled = false;
        }
    }
}
