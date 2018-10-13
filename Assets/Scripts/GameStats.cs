using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameStats/Stats")]
public class GameStats : ScriptableObject {
    private int currentScore = 0;

    private List<int> highscores;
    private int playerLane;
    private int playerLaneCount;

    public void OnEnable() {
<<<<<<< HEAD

        highscores = new List<int>() {100, 200, 50};
        playerLane = 0;
=======
        highscores = new List<int>();
>>>>>>> save current score in gamestats
    }

    public void SetCurrentScore(int newScore) {
        currentScore = newScore;
    }

    public void SetNewHighScore(int newScore) {
        currentScore = newScore;

        if (currentScore > 0)
        {
            highscores.Add(currentScore);
        }
    }

    public int GetCurrentScore() {
        return currentScore;
    }

    public List<int> GetHighscores() {
        highscores.Sort((a, b) => -1 * a.CompareTo(b));
        return highscores;
    }

    public void SetPlayerLane(int lane){
        this.playerLane = lane;
    }

    public int GetPlayerLane()
    {
        return this.playerLane;
    }

    public int GetPlayerLaneCount()
    {
        return this.playerLaneCount;
    }

    public void PlayerLaneIncrement(){
        this.playerLaneCount += 1;
    }

    public void PlayerLaneReset(){
        this.playerLaneCount = 0;
    }
}
