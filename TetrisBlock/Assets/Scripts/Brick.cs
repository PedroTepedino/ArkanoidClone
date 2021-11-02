using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float FallSpeed = 0;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = Vector2.down * FallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Score++;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        Destroy(gameObject);
    }
}
