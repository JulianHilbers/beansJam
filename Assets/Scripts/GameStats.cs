using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameStats/Stats")]
public class GameStats : ScriptableObject {
    private int currentScore = 20;

    private List<int> highscores;

    public void OnEnable() {
        highscores = new List<int>();
    }

    public void SetCurrentScore(int newScore) {
        if (currentScore > 0) {
            highscores.Add(currentScore);
        }
        currentScore = newScore;
    }

    public int GetCurrentScore() {
        return 20;
    }

    public List<int> GetHighscores() {
        return highscores;
    }
}
