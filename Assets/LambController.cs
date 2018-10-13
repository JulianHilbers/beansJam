using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambController : MonoBehaviour
{

    public float moveSteps = 1f;


    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            MoveUp();

        if (Input.GetKey(KeyCode.DownArrow))
            MoveDown();
    }

    public void MoveUp()
    {
        rBody.AddForce(Vector2.up * moveSteps);
    }

    public void MoveDown()
    {
        rBody.AddForce(Vector2.down * moveSteps);
    }
}
