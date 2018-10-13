using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambController : MonoBehaviour
{
    public float moveSteps = 1f;

    private Rigidbody2D rBody;
    private float initialY;

    private void Start()
    {
        initialY = transform.position.y;
        rBody = GetComponent<Rigidbody2D>();
    }

    public void MoveUp()
    {
        rBody.AddForce(Vector2.up * moveSteps);
    }

    public void MoveDown()
    {
        if (transform.position.y >= initialY)
            rBody.AddForce(Vector2.down * moveSteps);
    }
}
