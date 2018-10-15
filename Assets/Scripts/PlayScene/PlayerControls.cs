using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float destinationX;
    private float destinationY;

    public float forceScaleFactor = 15f;
    public float offsetY = 0.5f;
    public float laneDistance = 2f;
    public int lane = 0;

    [Header("Audio")]
    public AudioSource soundLeft;
    public AudioSource soundRight;

    [Space()]
    public GameStats stats;

    private Animator animator;
    private Rigidbody2D rb2d;
    private Vector2 force = Vector2.zero;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destinationX = 0;
        destinationY = 0;
    }

    void Update()
    {
        destinationY = destinationY * 0.95f;

        force.y = destinationY - transform.position.y - offsetY;
        force.x = destinationX - transform.position.x;

        rb2d.AddForce(force * forceScaleFactor);
    }

    public void IncreaseLane()
    {
        if (lane < 1 && animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            lane++;
            destinationX = lane * laneDistance;

            soundRight.Play();
            stats.SetPlayerLane(lane);
            animator.SetTrigger("TurnRightTrigger");
        }
    }

    public void DecreaseLane()
    {
        if (lane > -1 && animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            lane--;
            destinationX = lane * laneDistance;

            soundLeft.Play();
            stats.SetPlayerLane(lane);
            animator.SetTrigger("TurnLeftTrigger");
        }
    }

    public void IncreaseXDestination() { }

    public void IncreaseYDestination(float value)
    {
        destinationY += value;
    }
}
