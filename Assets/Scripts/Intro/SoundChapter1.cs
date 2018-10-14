using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChapter1 : MonoBehaviour {

    private float chapterStartTime;

    public AudioSource door;
    public float doorTime;

    private void OnEnable() {
        chapterStartTime = Time.time;

        door.PlayDelayed(doorTime);
    }

    // Use this for initialization
    void Start () {
	}
	
}
