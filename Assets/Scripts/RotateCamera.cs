using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    private float HorizontalInput
    {
        get => Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, -(HorizontalInput * rotationSpeed * Time.deltaTime));
    }
}
