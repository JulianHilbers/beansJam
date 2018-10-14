using UnityEngine;
using System.Collections;

public class Obstacle : Spawnable
{
    public void OnHit()
    {
        if (GetComponent<Animator>()) {
            GetComponent<Animator>().SetTrigger("obstacleHit");
        }
    }

    public override void ReSpawn(int lane)
    {
        if (GetComponent<Animator>()) {
            GetComponent<Animator>().SetTrigger("resetHit");
        }
        base.ReSpawn(lane);
    }
}
