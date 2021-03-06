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
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.LosePoints(5);
        }
        else if (!other.gameObject.CompareTag("Ball"))
        {
            GameManager.LosePoints(2);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.LosePoints(2);
        Destroy(gameObject);
    }
}