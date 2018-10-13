using UnityEngine;
using System.Collections.Generic;

public class BackgroundLoop : MonoBehaviour
{
    public float VerticalLength { get; set; }
    public List<Sprite> sprites;

    private BoxCollider2D streetCollider;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        streetCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.y < -VerticalLength)
        {
            Reposition();
            SwitchSprite();
        }
    }

    private void SwitchSprite()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    public void Reposition()
    {
        Vector3 pos = transform.position = transform.position;
        pos.y += VerticalLength * 2f;
        transform.position = pos;
    }
}
