using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Spawnable
{
    private float coolDown = 0f;
    private bool isOnTrack = true; 

    public void OnHit() {
        GetComponent<Animator>().SetTrigger("BottleBreak");
        this.isOnTrack = false;
    }

    public override void ReSpawn(int lane){
        GetComponent<Animator>().SetTrigger("BottleReset");
        coolDown = Time.time + Random.Range(5, 15);
        base.ReSpawn(lane);
        this.isOnTrack = true;
    }


    public bool CooledDown() {
        return coolDown > Time.time;
    }
   
}
