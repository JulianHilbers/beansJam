using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeepIAmSheep : MonoBehaviour {

    public Vector3 endPosition;

    public float waitTime = 1f;

    private float beginningTime;
    private float startMoveTime;

    private MeepSheepState meepSheepState = MeepSheepState.WAIT;
    private AnimationState animationState = AnimationState.DO;
    private float animationDoneTime;
    private float animationWaitTime = 1f;

	// Use this for initialization
	void Start () {
        this.beginningTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(meepSheepState == MeepSheepState.WAIT && beginningTime + waitTime < Time.time) {
            meepSheepState = MeepSheepState.MOVE;
            startMoveTime = Time.time;
        } else if (meepSheepState == MeepSheepState.MOVE) {
            float currentSlerpPosition = (Time.time - startMoveTime) / 4f;
            transform.localPosition = Vector3.Slerp(transform.localPosition, endPosition, currentSlerpPosition); // * Time.deltaTime);
            if (transform.localPosition.Equals(endPosition)) {
                meepSheepState = MeepSheepState.DONE;
            }
        } else if (meepSheepState == MeepSheepState.DONE) {
            DoRotate();
        }
		
	}

    public void DoRotate() {
        if(animationState == AnimationState.DO) {
            Hashtable hash = new Hashtable();
            hash.Add("amount", new Vector3(0f, 0f, 3f));
            hash.Add("time", .3f);
            hash.Add("oncomplete", "AnimationDone");
            iTween.ShakeRotation(gameObject, hash);
        } else if(Time.time - animationWaitTime > animationDoneTime) {
            AnimationDo();
        }
    }

    private void AnimationDone() {
        animationState = AnimationState.WAIT;
        animationDoneTime = Time.time;
    }

    private void AnimationDo() {
        animationState = AnimationState.DO;
    }


    enum AnimationState {
        DO,
        WAIT
    }

    enum MeepSheepState
    {
        WAIT,
        MOVE,
        DONE
    }
}
