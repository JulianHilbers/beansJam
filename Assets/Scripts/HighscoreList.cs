using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreList : MonoBehaviour {

    public GameObject scoreElementObject;
    public GameStats gameStats;

    public float spacing = 20f;

	// Use this for initialization
	void Start () {
        Debug.Log(gameStats.GetHighscores());
        List<int> highscores = gameStats.GetHighscores();
        int count = 0;
        foreach (int highscore in highscores) {
            GameObject newScoreElement = Instantiate(scoreElementObject, transform);
            ScoreElement scoreElement = newScoreElement.GetComponent<ScoreElement>();

            scoreElement.setScore(highscore);
            Debug.Log("score: " + highscore);

            scoreElement.transform.parent = transform;
            scoreElement.transform.localPosition = new Vector3(0, count * spacing, 0);


            count++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
