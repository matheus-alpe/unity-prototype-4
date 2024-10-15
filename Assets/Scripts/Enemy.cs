using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;

    private Vector3 LookDirection
    {
        get {
            if (player == null)
            {
                return new Vector3(0f, 0f, 0f);
            }
            return (player.transform.position - transform.position).normalized;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(LookDirection * speed);
    }
}
