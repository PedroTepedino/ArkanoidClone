using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(1, 1);
    [SerializeField] private float speed = 5;

    private Vector2 velocity = Vector2.zero;

    private Rigidbody2D body;

    private bool isLocked = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        velocity = direction.normalized * speed;
        body.bodyType = RigidbodyType2D.Kinematic;
        isLocked = true;
    }

    private void Update()
    {
        if (isLocked && Input.GetKeyDown(KeyCode.Space))
        {
            transform.parent = null;
            body.bodyType = RigidbodyType2D.Dynamic;
            isLocked = false;

            body.velocity = velocity;
        }

        if (isLocked) return;

        body.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Brick>() != null)
        {
            GameManager.GetPoint();
            Destroy(other.gameObject);

            // var newVelocity = Vector2.Reflect(body.velocity.normalized, other.contacts[0].normal);
            // body.velocity = newVelocity.normalized * speed;
            // return;
        }

        var contactAngle = Vector2.Angle(Vector2.right, other.contacts[0].point - (Vector2)this.transform.position);

        if (contactAngle >= 45 && contactAngle <= 135)
        {
            velocity.y = -velocity.y;
        }

        if (!(contactAngle > 45 && contactAngle < 135))
        {
            velocity.x = -velocity.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lost"))
        {
            GameManager.LosePoints(2);
            Destroy(this.gameObject);
            return;
        }
    }

    public void Unlock()
    {
        transform.parent = null;
        body.bodyType = RigidbodyType2D.Dynamic;
        isLocked = false;

        body.velocity = velocity;
    }
}