using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stiften : MonoBehaviour {

    public float timeUntilJump;
    public float runLength;
    private Vector3 runTargetPosition;
    private float chapterStartTime;
    private State state = State.STAND;


    private void OnEnable()
    {
        chapterStartTime = Time.time;

        runTargetPosition = new Vector3(transform.position.x + runLength, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (state == State.STAND && chapterStartTime + timeUntilJump < Time.time)
        {
            state = State.RUN;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.RUN)
        {
            transform.position = Vector3.MoveTowards(transform.position, runTargetPosition, 5f * Time.deltaTime);
        }
    }


    enum State
    {
        STAND,
        RUN
    }
}
