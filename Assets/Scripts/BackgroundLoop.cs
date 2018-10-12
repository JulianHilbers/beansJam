using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour {

    private BoxCollider2D streetCollider;
    public float verticalLength;

    // Use this for initialization
    void Awake () {
        streetCollider = GetComponent<BoxCollider2D>();
        verticalLength = streetCollider.size.y;
    }
    
    // Update is called once per frame
    void Update () {
        if (transform.position.y < - verticalLength){
            Reposition();
        }
    }

    void Reposition(){
        Vector2 groundOffset = new Vector2(0, verticalLength * 2f);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
