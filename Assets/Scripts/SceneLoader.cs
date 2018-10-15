using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
