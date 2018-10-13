using UnityEngine;
using System.Collections;

public class Spawnable : MonoBehaviour
{
    protected bool active = true;
    private float[] lanes = new float[] { -2.5f, 0.0f, 2.5f };
    public int speed = 4;

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

    public virtual void ReSpawn(int lane)
    {
        transform.position = new Vector3(lanes[lane], 10, 0);
        active = true;
    }

    public bool IsActive()
    {
        return active;
    }
}
