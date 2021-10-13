using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 direction = new Vector2(1,1);
    [SerializeField] private float speed = 5;

    private Vector2 velocity = Vector2.zero;
    
    private Rigidbody2D body;

    private bool isLocked = true;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        velocity = direction.normalized * speed;
        isLocked = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.parent = null;
            body.bodyType = RigidbodyType2D.Dynamic;
            isLocked = false;
        }

        if (isLocked) return;
        
        body.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
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
    
  
}
