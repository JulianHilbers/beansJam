using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollistionTrigger : MonoBehaviour {

    private BoxCollider2D bc2d;
    private Rigidbody2D rb2d;
    private Animator animator;

    // Use this for initialization
    void Start () {
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D other){
        Spawnable spawnable = other.GetComponent<Spawnable>();
        if (other.tag.Equals("PowerUp")){
            spawnable.GetComponent<PowerUp>().OnHit();
        }
        if (other.tag.Equals("Obstacle"))
        {
            rb2d.AddForce(new Vector3(0, -100));
            animator.SetTrigger("CrashTrigger");
            string colliderTag = other.tag;
            Debug.Log("Something has entered this zone: " + colliderTag);
        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
