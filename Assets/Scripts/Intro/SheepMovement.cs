using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour {
    private MovementState movementState = MovementState.NEXT;

    private Vector3 startLocalPosition;
    public Vector3 movementArea;
    public float movementSpeed;

    private Vector3 currentTarget;

    private float timeUntilRage = 3f;
    private float chapterStartTime;
    public Vector3 rageTargetPosition;
    public float rageSpeed;



    public void OnEnable() {
        chapterStartTime = Time.time;
        startLocalPosition = transform.position;
        //Debug.Log("start position: " + startLocalPosition);
        //Debug.Log("start localposition: " + transform.position);
    }

    public void SetMovementOn() {
        this.movementState = MovementState.MOVE;
    }

    public void SetMovementOff() {
        this.movementState = MovementState.STOP;
    }

    public void FixedUpdate() {
        if(movementState == MovementState.NEXT && chapterStartTime + timeUntilRage < Time.time) {
            movementState = MovementState.RAGE;
        }
    }

    public void Update() {
        if(movementState == MovementState.STOP) {
            return;
        }

        if(movementState == MovementState.NEXT) {
            currentTarget = GetRandomWithinBounds();
            movementState = MovementState.MOVE;
        }

        if(movementState == MovementState.MOVE) {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, movementSpeed * Time.deltaTime);
            if (!IsAtTarget()) {
                movementState = MovementState.NEXT;
            }
        }

        if (movementState == MovementState.RAGE) {
            transform.position = Vector3.MoveTowards(transform.position, rageTargetPosition, rageSpeed * Time.deltaTime);
            if(IsAtTarget()) {
                movementState = MovementState.STOP;
            }
        }
    }

    private bool IsAtTarget() {
        Vector3 t = movementState == MovementState.MOVE ? currentTarget : rageTargetPosition;
        return Vector3.Distance(transform.localPosition, currentTarget) < .05f;
    }

    private Vector3 GetRandomWithinBounds() {



        System.Random rand = new System.Random();
        float xMin = startLocalPosition.x - (movementArea.x / 2);
        float xMax = startLocalPosition.x + (movementArea.x / 2);
        
        float yMin = startLocalPosition.y - (movementArea.y / 2);
        float yMax = startLocalPosition.y + (movementArea.y / 2);

        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);

        return new Vector3(x, y, startLocalPosition.z);

    }

    enum MovementState{
        MOVE,
        NEXT,
        STOP,
        RAGE,
    }
}
