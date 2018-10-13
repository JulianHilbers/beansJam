using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float position = 20f;
    public float waitUntilFirtstSpawn = 4f;

    public int speed;
    public List<GameObject> list;
    public List<GameObject> clonedList;


    private float waitedTime = 0;
    private float[] lanes = new float[] { -2f, 0.0f, 2f };

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
                obj.GetComponent<Spawnable>().ReSpawn(newLane);
                lastLane = newLane;
             }

            if(!obj.activeSelf) {
                if (obj.GetComponent<PowerUp>().CooledDown()) {
                    obj.SetActive(true);
                    int newLane = GetLane(lastLane);
                    obj.GetComponent<Spawnable>().ReSpawn(newLane);
                    lastLane = newLane;
                }
            }
        });
    }

    private void InitializeObstacles()
    {
        float lastYpos = 14;
        int lastLane = 0;
        list.ForEach((GameObject obj) =>
        {
            GameObject clone = Instantiate(obj);

            int newLane = GetLane(lastLane);
            clone.transform.position = new Vector3(lanes[newLane], lastYpos, 0);

            clonedList.Add(clone);

            lastYpos -= position;
            lastLane = newLane;
        });
    }

   
}
