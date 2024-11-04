using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 100f;

    public void StartSpin()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
