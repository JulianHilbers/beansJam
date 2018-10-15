using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundLoop : MonoBehaviour
{
    public List<Sprite> sprites;
    public float VerticalLength { get; set; }

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -5.5f);
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
