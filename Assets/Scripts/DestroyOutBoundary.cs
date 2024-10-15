using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBoundary : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
