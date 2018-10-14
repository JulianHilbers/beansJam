using UnityEngine;
using System.Collections.Generic;

public class ObstacleController : MonoBehaviour
{
    public float position = 20f;
    public float waitUntilFirtstSpawn = 4f;

    public int speed;
    public List<GameObject> list;
    public List<GameObject> clonedList;

    private float waitedTime = 0;
    private float[] lanes = new float[] { -2f, 0, 2f };

    private bool initialized = false;

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
        if (waitedTime < waitUntilFirtstSpawn)
            waitedTime += Time.deltaTime;


        if (waitedTime >= waitUntilFirtstSpawn)
        {
            if (!initialized)
            {
                initialized = true;
                InitializeObstacles();
            }

            MoveObstacles();
        }
    }

    private void MoveObstacles()
    {
        int lastLane = 0;
        clonedList.ForEach((GameObject obj) =>
        {
            if (!obj.GetComponent<Spawnable>().IsActive())
            {
                int newLane = GetLane(lastLane);

                if (obj.GetComponent<Collider2D>().tag.Equals("PowerUp") && obj.GetComponent<PowerUp>().CooledDown())
                {
                    return;
                }

                obj.GetComponent<Spawnable>().ReSpawn(newLane);
                lastLane = newLane;
            }

        });
    }

    private void InitializeObstacles()
    {
        float lastYpos = 14;
        int lastLane = 0;
        list.ForEach((GameObject obj) =>
        {
            GameObject clone = Instantiate(obj, transform);

            int newLane = GetLane(lastLane);
            clone.transform.position = new Vector3(lanes[newLane], lastYpos, 0);
            clone.GetComponent<Spawnable>().Speed = speed;

            clonedList.Add(clone);

            lastYpos -= position;
            lastLane = newLane;
        });
    }


}