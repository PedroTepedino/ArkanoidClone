using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    public Sprite[] Sprites;

    private void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (renderer == null)
            return;

        renderer.sprite = Sprites[Random.Range(0, Sprites.Length)];
    }
}
