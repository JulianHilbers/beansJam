using UnityEngine;

public class LambController : MonoBehaviour
{
    public float waitUntilShow = 2f;
    public float moveForce = 1f;

    [Header("Scene")]
    public GameStats stats;
    public string sceneName;
    public SceneLoader SceneLoader;

    private Rigidbody2D rBody;
    private float initialY;
    private float waited;

    private void Start()
    {
        initialY = transform.position.y;
        rBody = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Update()
    {
        if (waited < waitUntilShow)
        {
            waited += Time.deltaTime;
        }
        else if (waited > waitUntilShow)
        {
            waitUntilShow = 0;
            waited = 0;

            GetComponent<BoxCollider2D>().enabled = true;
            MoveUp(30f);
        }
    }

    public void MoveUp()
    {
        MoveUp(moveForce);
    }

    public void MoveUp(float speed)
    {
        rBody.AddForce(Vector2.up * speed);
    }

    public void MoveDown()
    {
        if (transform.position.y >= initialY)
            rBody.AddForce(Vector2.down * moveForce);
    }

    public void GameFailed()
    {
        SceneLoader.LoadScene(sceneName);
        stats.AddHighScore(stats.GetCurrentScore());
    }
}
