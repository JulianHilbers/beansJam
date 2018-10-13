using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public int speed;
    public List<GameObject> list;

    private List<Obstacle> cloneList = new List<Obstacle>();
    private float[] lanes = new float[]{-2.5f, 0.0f, 2.5f};


    private void Start()
    {
        list.ForEach((GameObject obj) => {
            GameObject clone = Object.Instantiate(obj);
            int randomPos = Random.Range(0, lanes.Length);
            clone.transform.position = new Vector3(lanes[randomPos], -10, 0);

            cloneList.Add(new Obstacle() {
                transform = clone.transform,
                active = true,
                renderer = clone.GetComponent<Renderer>()
            });

        });
    }

    void FixedUpdate()
    {
        cloneList.ForEach((Obstacle obstacle) => {
            if (obstacle.active) {
                obstacle.transform.Translate(Vector2.down * Time.deltaTime * speed);
                
                if (!obstacle.renderer.isVisible && obstacle.renderer.transform.position.y < -2f) {
                    int randomPos = Random.Range(0, lanes.Length);
                    obstacle.transform.position = new Vector3(lanes[randomPos], 10, 0);
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