using UnityEngine;


public class CollistionTrigger : MonoBehaviour
{
    public LambController lambController;
    public GameObject deadAnimation;

    private Rigidbody2D rb2d;
    public float nextY;

    [Header("Audio")]
    public AudioSource soundCrash;
    public AudioSource soundPowerUp;


    private float waitUntilEnd = 1.5f;
    private float waited = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "lambs")
        {
            if (waited < waitUntilEnd)
                waited += Time.deltaTime;

            if (waited > waitUntilEnd)
                lambController.GameFailed();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Spawnable spawnable = other.GetComponent<Spawnable>();

        switch (other.tag)
        {
            case "PowerUp":
                spawnable.GetComponent<PowerUp>().OnHit();
                GetComponent<PlayerControls>().IncreaseYDestination(nextY);
                lambController.MoveDown();
                soundPowerUp.Play();
                break;

            case "Obstacle":
                Camera.main.GetComponent<CameraControl>().Shake(0.2f, 4, 100 * Time.deltaTime);
                rb2d.AddForce(new Vector3(0, -200));
                spawnable.GetComponent<Obstacle>().OnHit();
                string colliderTag = other.tag;
                lambController.MoveUp();
                soundCrash.Play();
                break;

            case "lambs":
                deadAnimation.SetActive(true);
                break;
        }
    }
}
