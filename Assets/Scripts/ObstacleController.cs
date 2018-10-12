using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public int speed;
    public List<GameObject> list;

    private List<Obstacle> cloneList = new List<Obstacle>();


    private void Start()
    {
        list.ForEach((GameObject obj) => {
            GameObject clone = Object.Instantiate(obj);
            clone.transform.position = Vector3.zero;

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
                    obstacle.active = false;
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