using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZLimit : MonoBehaviour
{
    [SerializeField]
    float zLimit1;

    [SerializeField]
    float zLimit2;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < zLimit1)
        {
            transform.position =new Vector3(transform.position.x,transform.position.y, zLimit1);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        }

        if (transform.position.z > zLimit2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit2);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        }

    }
}
