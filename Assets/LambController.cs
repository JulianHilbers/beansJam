using UnityEngine;

public class LambController : MonoBehaviour
{
    public float waitUntilShow = 2f;
    public float moveForce = 1f;
    public float failPosition = -3.5f;

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
    }

    private void Update()
    {
        CheckForFail();

        if (waited < waitUntilShow)
        {
            waited += Time.deltaTime;
        }
        else if (waited > waitUntilShow) {
            waitUntilShow = 0;
            waited = 0;

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

    private void CheckForFail()
    {
        if (transform.position.y > failPosition)
        {
            SceneLoader.LoadScene(sceneName);
            stats.AddHighScore(stats.GetCurrentScore());
        }
    }
}
