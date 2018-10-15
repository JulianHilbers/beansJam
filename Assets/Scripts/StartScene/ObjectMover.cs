using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public Vector3 valueToMove = Vector3.zero;

    public float waitUntilStart = 1f;
    public float movementDuration = 2f;

    private float waited;

    private MeepHighscoreState meepSheepState = MeepHighscoreState.WAIT;

    void Update()
    {
        switch (meepSheepState)
        {
            case MeepHighscoreState.WAIT:
                waited += Time.deltaTime;

                if (waited >= waitUntilStart)
                    meepSheepState = MeepHighscoreState.MOVE;

                break;
            case MeepHighscoreState.MOVE:
                StartCoroutine(MoveToPosition(transform, valueToMove, movementDuration));
                meepSheepState = MeepHighscoreState.DONE;
                break;
        }
    }

    IEnumerator MoveToPosition(Transform objTransform, Vector3 position, float duration)
    {
        Vector3 desiredPos = objTransform.localPosition + position;
        float mTime = 0f;
        while (mTime < 1)
        {
            mTime += Time.deltaTime / duration;
            objTransform.localPosition = Vector3.Lerp(objTransform.localPosition, desiredPos, mTime);
            yield return null;
        }
    }

    enum MeepHighscoreState
    {
        WAIT,
        MOVE,
        DONE
    }
}
