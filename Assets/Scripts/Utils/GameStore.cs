using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameStore
{
    private static string dataName = "store.dat";

    public static void SaveGameData(List<int> currentScores)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + dataName);

        GameData gs = new GameData
        {
            scores = currentScores
        };

        bf.Serialize(file, gs);
        file.Close();
    }

    public static List<int> LoadGameData()
    {
        List<int> result = new List<int>();

        if (File.Exists(Application.persistentDataPath + "/" + dataName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + dataName, FileMode.Open);
            GameData gs = (GameData)bf.Deserialize(file);

            return gs.scores;
        }

        return result;
    }
}

[System.Serializable]
class GameData
{
    public List<int> scores;
}
