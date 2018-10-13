using UnityEngine;
using UnityEngine.UI;

public class ScoreElement : MonoBehaviour {

    private Text scoreText;


    public void Start() {
        scoreText = GetComponent<Text>();
    }

    public void setScore(int score) {
        if(scoreText == null) {
            scoreText = GetComponent<Text>();
        }
        scoreText.text = score + "";
    }
}