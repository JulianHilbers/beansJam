using UnityEngine;
using System.Collections;

public class Spawnable : MonoBehaviour
{
    public GameStats stats;

    protected bool active = true;
    private float[] lanes = new float[] { -2.5f, 0.0f, 2.5f };
    public int speed = 4;

    private int lastPlayerLane;
    private int currentPlayerLane = 0;
    private int playerLaneCount;

    void FixedUpdate()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        if (active)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }

        if (!renderer.isVisible && renderer.transform.position.y < -2f)
        {
            active = false;
        }
    }

    public virtual void ReSpawn(int lane){
        IncrementNoObstaclePlayerLaneCountIfStillOnLane();
        int nextLane = lane;

        if (stats.GetPlayerLaneCount() > Random.Range(1, 3))
        {
            stats.PlayerLaneReset();
            nextLane = stats.GetPlayerLane() + 1;
            Debug.Log(stats.GetPlayerLane());
        }
        transform.position = new Vector3(lanes[nextLane], 10, 0);
        active = true;

    }

    public bool IsActive()
    {
        return active;
    }

    private void IncrementNoObstaclePlayerLaneCountIfStillOnLane(){
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
