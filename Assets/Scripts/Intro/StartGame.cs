using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public AudioSource doorSound;

    public float timeTillDoorSound;
    private bool soundPlayed = false;

    public float timeTillGameStart;
    public ChapterController chapterController;
    private float chapterStartTime;

    private void OnEnable() {
        chapterStartTime = Time.time;
    }

	
	// Update is called once per frame
	void Update () {
        if (!soundPlayed && chapterStartTime + timeTillDoorSound < Time.time) {
            soundPlayed = true;
            doorSound.Play();
        }
        if (soundPlayed && !doorSound.isPlaying) {
            chapterController.NextChapter();
        }
	}
}
