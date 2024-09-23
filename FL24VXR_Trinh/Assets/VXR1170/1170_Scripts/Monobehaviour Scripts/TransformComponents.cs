using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponents : MonoBehaviour
{
    public Transform target;



    // Update is called once per frame
    void Update()
    {
        MoveCube();

        RotateCube();

        ScaleCube();

        if (Input.GetKeyDown(KeyCode.L))
        {
            LookAtTarget();
        }
    }

    private void MoveCube()
    {
        float moveSpeed = 5f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime; // Move forward
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;     // Move backward
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;    // Move left
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;   // Move right
        }
    }

    void RotateCube()
    {
        // Rotate the cube around the Y-axis (up/down) with Q and E keys
        float rotationSpeed = 50f;
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime); // Rotate left
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);  // Rotate right
        }
    }

    void ScaleCube()
    {
        // Scale the cube uniformly with w and s keys
        Vector3 scaleChange = new Vector3(1, 1, 1) * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += scaleChange; // Increase size
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale -= scaleChange; // Decrease size
        }
    }

    void LookAtTarget()
    {
        // Rotate the cube to look at a target GameObject
        if (target != null)
        {
            transform.LookAt(target);  // Rotate the cube to face the target
        }
        else
        {
            Debug.LogWarning("No target assigned for LookAt.");
        }
    }
}
