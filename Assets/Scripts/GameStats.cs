using UnityEngine;
using System.Collections.Generic;

public class GameStats : ScriptableObject {
    private int CurrentScore;

    private List<int> highscores;

    public void OnEnable() {
        highscores = new List<int>();
    }

    public void SetCurrentScore(int newScore) {
        if (CurrentScore > 0) {
            highscores.Add(CurrentScore);
        }
        CurrentScore = newScore;
    }

    public int GetCurrentScore() {
        return CurrentScore;
    }

    public List<int> GetHighscores() {
        return highscores;
    }
}
