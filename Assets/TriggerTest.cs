using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    public LambController lambController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Obstacle":
                lambController.MoveUp();
                break;
            case "PowerUp":
                lambController.MoveDown();
                break;
        }
    }
}
