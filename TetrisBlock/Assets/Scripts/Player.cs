using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var input = Input.GetAxisRaw("Horizontal");
        if (input > 0.2f)
        {
            rigidbody.velocity = new Vector3(input, 0, 0) * speed;
        }
        else if (input < -0.2f)
        {
            rigidbody.velocity = new Vector3(input, 0, 0) * speed;
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
