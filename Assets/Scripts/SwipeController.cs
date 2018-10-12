using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public float swipeVerticalRecognition = 30f;
    public float swipeHorizontalRecognition = 30f;


    private Vector2 swipeStartPos;

    private void HandleToches()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                swipeStartPos = touch.position;
                OnTouchBegan(touch.position);
                break;

            case TouchPhase.Moved:
                OnTouchMoved(touch.position, touch.position - swipeStartPos);
                break;

            case TouchPhase.Stationary:
                OnTouchStay(touch.position);
                break;

            case TouchPhase.Ended:
                HandleSwipe(touch);
                OnTouchEnd(touch.position);
                break;
        }
    }

    private void OnTouchBegan(Vector2 position)
    {

    }

    private void OnTouchEnd(Vector2 position)
    {

    }

    private void OnTouchStay(Vector2 position)
    {

    }

    private void OnTouchMoved(Vector2 position, Vector2 direction)
    {

    }

    private void OnTouchBegan(Vector2 position, Vector3 direction)
    {

    }

    private void OnSwipedHorizontally(Vector2 position, float direction)
    {
        if (direction > 0)
        {
            Debug.Log("right");
        }
        else if (direction < 0)
        {
            Debug.Log("left");
        }
    }

    private void HandleSwipe(Touch touch)
    {
        Vector2 touchPos = touch.position;
        Vector2 direction = touchPos - swipeStartPos;

        if (direction.x > swipeHorizontalRecognition || direction.x < -swipeHorizontalRecognition)
        {
            OnSwipedHorizontally(touch.position, direction.x);
        }
    }


    private void Update()
    {
        HandleToches();
    }

}
