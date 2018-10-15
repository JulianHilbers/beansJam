using UnityEngine;

public class TouchController : MonoBehaviour
{
    public PlayerControls playerControls;

    public float swipeVerticalRecognition = 30f;
    public float swipeHorizontalRecognition = 30f;


    private Vector2 swipeStartPos;
    private float screenHalf;

    private void HandleToches()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                swipeStartPos = touch.position;
                OnTouchStart(touch.position);
                break;

            case TouchPhase.Ended:
                OnTouchEnd(touch.position);
                break;
        }
    }

    private void OnTouchStart(Vector2 position) { }

    private void OnTouchEnd(Vector2 position)
    {
        if (position.x > screenHalf)
        {
            playerControls.IncreaseLane();
        }
        else
        {
            playerControls.DecreaseLane();
        }
    }

    private void OnSwipedHorizontally(Vector2 position, float direction)
    {
        if (direction > 0)
        {
            playerControls.IncreaseLane();
        }
        else if (direction < 0)
        {
            playerControls.DecreaseLane();
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

    private void Start()
    {
        screenHalf = Screen.width / 2;
    }

    private void Update()
    {
        HandleToches();
    }
}
