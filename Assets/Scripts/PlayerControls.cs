using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private float yVelocity = 0.0f;
    private float laneDistance = 3f;
    public int lane = 0;

    private Rigidbody2D rb2d;
    
    public float velo;
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float newPosition = Mathf.SmoothDamp(transform.position.x, lane * laneDistance, ref yVelocity, 0.3f);
        transform.position = new Vector3(newPosition, 0, 0);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            IncreaseLane();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            DecreaseLane();
    }

    void IncreaseLane() {
        if (lane < 1) {
            lane++;
        }
    }

    void DecreaseLane()
    {
        if (lane > -1)
        {
            lane--;
        }
    }

}
