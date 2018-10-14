using UnityEngine;


public class CollistionTrigger : MonoBehaviour
{
    public LambController lambController;

    private BoxCollider2D bc2d;
    private Rigidbody2D rb2d;
    private Animator animator;
    public float testY;

    [Header("Audio")]
    public AudioSource soundCrash;
    public AudioSource soundPowerUp;


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
            GetComponent<PlayerControls>().IncreaseYDestination(testY);
            lambController.MoveDown();
            soundPowerUp.Play();
        }
        if (other.tag.Equals("Obstacle"))
        {
            Camera.main.GetComponent<CameraControl>().Shake(0.2f, 4, 100 * Time.deltaTime);
            rb2d.AddForce(new Vector3(0, -200));
            spawnable.GetComponent<Obstacle>().OnHit();
            string colliderTag = other.tag;
            lambController.MoveUp();
            soundCrash.Play();
        }

    }
}
