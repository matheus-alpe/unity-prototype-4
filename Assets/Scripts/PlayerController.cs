using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : Powerup
{
    public float speed = 5.0f;
    private InputControl control;

    private Rigidbody rb;
    private GameObject focalPoint;


    // Start is called before the first frame update
    void Start()
    {
        control = gameObject.AddComponent<InputControl>();
        control.speed = speed;
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForce(control.Movement);
    }
}
