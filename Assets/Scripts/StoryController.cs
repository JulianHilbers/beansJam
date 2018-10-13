using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour {

    public List<GameObject> chapterList;
    public string nextSceneName = "GameScene";
    public SceneLoader sceneController;

    private int currentChapter = 0;

    public void Start() {
        GameObject nextChapter = chapterList[currentChapter];
        Instantiate(nextChapter, transform);
    }

    public void NextChapter() {
        currentChapter++;
        GameObject nextChapter = chapterList[0];
        Instantiate(nextChapter, transform);

    }

    private void StartNextScene() {
        sceneController.LoadScene(nextSceneName);
    }


}
