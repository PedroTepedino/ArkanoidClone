using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Score++;
        gameObject.SetActive(false);
    }
}
