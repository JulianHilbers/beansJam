using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public GameStats gameStats;

    void Start()
    {
        gameStats.highscores = GameStore.LoadGameData();
    }
}
