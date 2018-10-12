using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveIn : MonoBehaviour {
    private float yVelocity = 0.0f;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
    void Update () {
        if (System.Math.Abs(transform.position.y) > 0.1)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.y, 0, ref yVelocity, 0.9f);
            transform.position = new Vector3(0, newPosition, 0);
        }
    }
}
