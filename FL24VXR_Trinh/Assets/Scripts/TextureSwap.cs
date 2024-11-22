using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwap : MonoBehaviour
{
    public Material material;  // The material to apply the texture to
    public Texture2D texture1; // The starting texture
    public Texture2D texture2; // The target texture
    public float duration = 2f; // Duration of the transition

    private Texture2D blendedTexture;

    private void Start()
    {
        // Ensure the material has a texture to work with
        blendedTexture = new Texture2D(texture1.width, texture1.height);
        StartCoroutine(SwapTextures());
    }

    private IEnumerator SwapTextures()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float blendFactor = Mathf.Clamp01(elapsed / duration);

            BlendTextures(blendFactor);
            material.mainTexture = blendedTexture;

            yield return null;
        }

        // Ensure the final texture is applied
        material.mainTexture = texture2;
    }

    private void BlendTextures(float blendFactor)
    {
        Color[] colors1 = texture1.GetPixels();
        Color[] colors2 = texture2.GetPixels();
        Color[] blendedColors = new Color[colors1.Length];

        for (int i = 0; i < colors1.Length; i++)
        {
            blendedColors[i] = Color.Lerp(colors1[i], colors2[i], blendFactor);
        }

        blendedTexture.SetPixels(blendedColors);
        blendedTexture.Apply();
    }
}
