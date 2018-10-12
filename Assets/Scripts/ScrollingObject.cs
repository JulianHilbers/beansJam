using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //todo in config
        rb2d.velocity = new Vector2(0, -1.5f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
