using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int speed;
    public float startY;

    private int[] lanes = new int[] { 1, 3, 5 };

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    void OnBecameInvisible()
    {
        int randomPos = Random.Range(0, lanes.Length);
        Debug.Log(randomPos);
        transform.position = new Vector3(lanes[randomPos], startY, 0);
    }
}
