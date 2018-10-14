using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {

    public void FixedUpdate()
    {
        DoPulse();
    }

    public void DoPulse()
    {
        System.Collections.Hashtable hash =
                  new System.Collections.Hashtable();
        hash.Add("amount", new Vector3(0.15f, 0.15f, 0f));
        hash.Add("time", 1f);
        iTween.PunchScale(gameObject, hash);
    }
} 
