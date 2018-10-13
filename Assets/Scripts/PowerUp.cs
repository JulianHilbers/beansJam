using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Spawnable
{
    public void OnHit() {
        active = false;
        gameObject.SetActive(false);
    }
   
}
