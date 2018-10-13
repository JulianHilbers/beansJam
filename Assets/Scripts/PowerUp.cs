using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Spawnable
{
    public float coolDownPeriodInSecs = 5f;
    private float coolDown = 0f;

    public void OnHit() {
        active = false;
        gameObject.SetActive(false);
        coolDown = Time.time + coolDownPeriodInSecs;
    }

    public bool CooledDown() {
        if (coolDown == 0f || coolDown <= Time.time) {
            return true;
        }
        return false;
    }
   
}
