using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float position = 20f;
    public int speed;
    public List<GameObject> list;
    public List<GameObject> clonedList;

    private float[] lanes = new float[]{-2.5f, 0.0f, 2.5f};


    private void Start()
    {
        float lastYpos = 10;
        int lastLane = 0;
        list.ForEach((GameObject obj) => {
            GameObject clone = Object.Instantiate(obj);

            int newLane = GetLane(lastLane);
            clone.transform.position = new Vector3(lanes[newLane], lastYpos, 0);

            clonedList.Add(clone);

            lastYpos -= position;
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

    private void FixedUpdate()
    {
        int lastLane = 0;
        clonedList.ForEach((GameObject obj) => {
            if (!obj.GetComponent<Spawnable>().isActive()) {
                int newLane = GetLane(lastLane);
                obj.GetComponent<Spawnable>().ReSpawn(newLane);
                lastLane = newLane;
            }
        });
    }
}
