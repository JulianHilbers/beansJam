using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {

    public GameStats gamestats;

	void Start()
    {
        GameObject.Find("Score").GetComponent<Text>().text = gamestats.GetCurrentScore() + " m";



        string text = "";
        int place = 1;



        gamestats.GetHighscores().ForEach((int score) => {
            text += place + "\t " + score + "\n";
            place++;
        });

        GameObject.Find("ScoreList").GetComponent<Text>().text = text;

    }
}
