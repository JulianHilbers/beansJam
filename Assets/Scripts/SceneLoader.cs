using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int level)
    {
        Debug.Log("Load Level: " + level);
        SceneManager.LoadScene(level);

    }

    public void LoadScene(string levelName) {
        Debug.Log("Load Level(name): " + levelName);
        SceneManager.LoadScene(levelName);
    }

}
