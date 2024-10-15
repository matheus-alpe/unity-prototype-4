using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : Powerup
{
    private Rigidbody rb;
    private GameObject focalPoint;
    private float VerticalInput
    {
        get => Input.GetAxis("Vertical");
    }

    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        rb.AddForce(VerticalInput * speed * focalPoint.transform.forward);
    }
}
