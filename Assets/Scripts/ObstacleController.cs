using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int position = 2;
    public int speed;
    public List<GameObject> list;

    private List<Obstacle> cloneList = new List<Obstacle>();
    private float[] lanes = new float[]{-2.5f, 0.0f, 2.5f};


    private void Start()
    {
        float lastYpos = -10;
        int lastLane = 0;
        list.ForEach((GameObject obj) => {
            GameObject clone = Object.Instantiate(obj);

            int newLane = GetLane(lastLane);
            clone.transform.position = new Vector3(lanes[newLane], lastYpos, 0);

            cloneList.Add(new Obstacle() {
                transform = clone.transform,
                active = true,
                renderer = clone.GetComponent<Renderer>()
            });
            lastYpos -= position;
            Debug.Log(lastYpos);
            lastLane = newLane;
        });
    }

    private int GetLane(int lastLane)
    {
        bool searchingNewLane = true;
        int newLane = 0;
        while (searchingNewLane)
        {
            newLane = Random.Range(0, lanes.Length);
            if (newLane != lastLane)
            {
                searchingNewLane = false;
            }
        }
        return newLane;
    }

    void FixedUpdate()
    {
        int lastLane = 0;
        cloneList.ForEach((Obstacle obstacle) => {
            if (obstacle.active) {
                obstacle.transform.Translate(Vector2.down * Time.deltaTime * speed);
                
                if (!obstacle.renderer.isVisible && obstacle.renderer.transform.position.y < -2f) {
                    int newLane = GetLane(lastLane);
                    obstacle.transform.position = new Vector3(lanes[newLane], 10, 0);
                    lastLane = newLane;
                }
            }

        });
    }
}

[System.Serializable]
public class Obstacle
{
    public Transform transform;
    public bool active;
    public Renderer renderer;
}