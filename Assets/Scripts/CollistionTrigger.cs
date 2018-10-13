using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollistionTrigger : MonoBehaviour {

    private BoxCollider2D bc2d;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something has entered this zone.");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
