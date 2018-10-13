using UnityEngine;


public class CollistionTrigger : MonoBehaviour
{
    public LambController lambController;

    private BoxCollider2D bc2d;
    private Rigidbody2D rb2d;
    private Animator animator;
    public float testY;

    void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Spawnable spawnable = other.GetComponent<Spawnable>();
        if (other.tag.Equals("PowerUp"))
        {
            spawnable.GetComponent<PowerUp>().OnHit();
            //rb2d.AddForce(new Vector3(0, +1000));
            GetComponent<PlayerControls>().IncreaseYDestination(testY);
            lambController.MoveDown();
        }
        if (other.tag.Equals("Obstacle"))
        {
            Camera.main.GetComponent<CameraControl>().Shake(0.2f, 4, 100 * Time.deltaTime);

            rb2d.AddForce(new Vector3(0, -200));
            animator.SetTrigger("CrashTrigger");
            string colliderTag = other.tag;
            lambController.MoveUp();
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
