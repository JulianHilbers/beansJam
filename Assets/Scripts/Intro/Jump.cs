using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float timeUntilJump;
    public float jumpHeight;
    private Vector3 jumpTargetPosition;
    public Vector3 startPosition;
    private float chapterStartTime;
    private State state = State.STAND;


    private void OnEnable() {
        chapterStartTime = Time.time;
        //startPosition = transform.position;

        jumpTargetPosition = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);
    }

    private void FixedUpdate() {
        if(state != State.DOWN && state != State.NUFFIN && chapterStartTime + timeUntilJump < Time.time) {
            state = State.UP;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (state == State.UP && IsAtTarget())
        {
            state = State.DOWN;
        }
        if (state == State.UP) {
            transform.position = Vector3.MoveTowards(transform.position, jumpTargetPosition, 12f * Time.deltaTime);
        }
        if(state == State.DOWN) {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 12f * Time.deltaTime);
            if (IsAtTarget()) {
                state = State.NUFFIN;
            }
        }
	}

    private bool IsAtTarget() {
        Vector3 t = state == State.UP ? jumpTargetPosition : startPosition;
        return Vector3.Distance(transform.position, t) < .05f;
    }

    enum State {
        STAND,
        UP,
        DOWN,
        NUFFIN
    }
}
