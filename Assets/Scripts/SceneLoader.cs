using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int level)
    {
        Debug.Log("Load Level: " + level);
    }

    public void LoadScene(string levelName) {
        Debug.Log("Load Level(name): " + levelName);
    }

}
