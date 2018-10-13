using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    public Text textComp;
    public Text scoreComp;
    public GameStats gamestats;

    void Start()
    {
        textComp.text = gamestats.GetCurrentScore() + " m";

        string text = "";
        int place = 1;

        gamestats.GetHighscores().ForEach((int score) =>
        {
            text += place + "\t " + score + " \t Punkte\n";
            place++;
        });

        scoreComp.text = text;
    }
}
