using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    public Text textComp;
    public Text scoreComp;
    public GameObject retryButton;

    [Space()]
    public GameStats gamestats;

    void Start()
    {
        retryButton.SetActive(gamestats.isScroreAfterPlay);

        textComp.text = gamestats.GetCurrentScore() + " m";

        if (gamestats.isScroreAfterPlay)
        {
            gamestats.AddHighScore(gamestats.GetCurrentScore());
            StoreScores();
        }

        string text = "";
        int place = 1;

        gamestats.GetHighscores().ForEach((int score) =>
        {
            text += place + "# \t" + score + " m\n";
            place++;
        });

        scoreComp.text = text;
    }

    private void StoreScores()
    {
        GameStore.SaveGameData(gamestats.GetHighscores());
    }
}
