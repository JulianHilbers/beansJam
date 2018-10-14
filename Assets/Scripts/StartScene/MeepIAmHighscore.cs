using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeepIAmHighscore : MonoBehaviour {

    public Vector3 endPosition;

    public float waitTime;

    private float beginningTime;
    private float startMoveTime;

    private float absoluteY;

    private MeepHighscoreState meepSheepState = MeepHighscoreState.WAIT;

    // Use this for initialization
    void Start()
    {
        this.beginningTime = Time.time;
        absoluteY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (meepSheepState == MeepHighscoreState.WAIT && beginningTime + waitTime < Time.time)
        {
            meepSheepState = MeepHighscoreState.MOVE;
            startMoveTime = Time.time;
        }
        else if (meepSheepState == MeepHighscoreState.MOVE)
        {
            float currentSlerpPosition = (Time.time - startMoveTime) / 2.5f;
            transform.localPosition = Vector3.Slerp(transform.localPosition, endPosition, currentSlerpPosition);
            transform.localPosition = new Vector3(transform.localPosition.x, absoluteY, transform.localPosition.z);
        }

    }

    enum MeepHighscoreState
    {
        WAIT,
        MOVE,
        DONE
    }
}
