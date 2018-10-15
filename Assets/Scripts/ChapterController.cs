using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterController : MonoBehaviour
{
    public List<GameObject> chapterList;
    public string nextSceneName = "GameScene";
    public SceneLoader sceneController;

    private int currentChapter = 0;

    public void Start()
    {
        SetChapterVisible(0);
    }

    private void SetChapterVisible(int chapterNumber)
    {
        int counter = 0;
        foreach (GameObject chapterObject in chapterList)
        {
            if (counter == chapterNumber)
            {
                chapterObject.SetActive(true);
            }
            else
            {
                chapterObject.SetActive(false);
            }
            counter++;

        }
    }

    public void NextChapter()
    {
        currentChapter++;
        if (chapterList.Count > currentChapter)
        {
            SetChapterVisible(currentChapter);
        }
        else
        {
            StartNextScene();
        }
    }

    private void StartNextScene()
    {
        sceneController.LoadScene(nextSceneName);
    }
}
