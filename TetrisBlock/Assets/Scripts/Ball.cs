using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(1,1);
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
        
        // if (isLocked) return;
        //
        // body.velocity = velocity;
    }

    private void LateUpdate()
    {
        if (isLocked)
            return;
        
        var angle = Vector2.Angle(Vector2.right, body.velocity);
        
        Vector2 newVelocity = body.velocity.normalized;
        
        if ((0 <= angle && angle <= 20) || (160 <= angle && angle <= 180) )
        {
            newVelocity += Vector2.up * Random.Range(0.1f, 0.5f);
        }
        
        if ((70 <= angle && angle <= 90) || (270 <= angle && angle <= 290))
        {
            newVelocity += Vector2.right * Random.Range(0.1f, 0.5f);
        }

        if ((180 <= angle && angle <= 200) || (340 <= angle && angle <= 360))
        {
            newVelocity += Vector2.down * Random.Range(0.1f, 0.5f);
        }
        
        if ((90 <= angle && angle <= 112) || (250 <= angle && angle <= 270))
        {
            newVelocity += Vector2.left * Random.Range(0.1f, 0.5f);
        }

        body.velocity = newVelocity.normalized * speed;


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // var contactAngle = Vector2.Angle(Vector2.right, other.contacts[0].point - (Vector2)this.transform.position);
        //
        // if (contactAngle >= 45 && contactAngle <= 135)
        // {
        //     velocity.y = -velocity.y;
        // }
        //
        // if (!(contactAngle > 45 && contactAngle < 135))
        // {
        //     velocity.x = -velocity.x;
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lost"))
        {
            Destroy(this.gameObject);
            return;
        }

        // var contactAngle = Vector2.Angle(Vector2.right, other.OverlapPoint() contacts[0].point - (Vector2)this.transform.position);
        //
        // if (contactAngle >= 45 && contactAngle <= 135)
        // {
        //     velocity.y = -velocity.y;
        // }
        //
        // if (!(contactAngle > 45 && contactAngle < 135))
        // {
        //     velocity.x = -velocity.x;
        // }
    }
}
