using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public GameStats stats;
    public float respawnAt = -6f;

    protected bool active = true;
    private float[] lanes = new float[] { -2.5f, 0, 2.5f };
    public float Speed { get; set; } = 3.5f;

    private int lastPlayerLane;
    private int currentPlayerLane = 0;
    private int playerLaneCount;

    void FixedUpdate()
    {

        Renderer renderer = gameObject.GetComponent<Renderer>();

        if (active)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }

        if (renderer.transform.position.y <= respawnAt)
        {
            active = false;
        }
    }

    public virtual void ReSpawn(int lane)
    {
        IncrementNoObstaclePlayerLaneCountIfStillOnLane();
        int nextLane = lane;
        //spawn an obsticle in player lane if he stays to long on one lane
        if (stats.GetPlayerLaneCount() > Random.Range(1, 3) && !GetComponent<PowerUp>())
        {
            stats.PlayerLaneReset();
            nextLane = stats.GetPlayerLane() + 1;
        }

        transform.position = new Vector3(lanes[nextLane], 10, 0);
        active = true;

    }

    public bool IsActive()
    {
        return active;
    }

    private void IncrementNoObstaclePlayerLaneCountIfStillOnLane()
    {
        lastPlayerLane = currentPlayerLane;
        currentPlayerLane = stats.GetPlayerLane();

        if (currentPlayerLane == lastPlayerLane)
        {
            stats.PlayerLaneIncrement();
        }
        else
        {
            stats.PlayerLaneReset();
        }
    }
}
