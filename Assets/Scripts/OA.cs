using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OA : MonoBehaviour {

    [Header("Scene")]
    public SceneLoader sceneLoader;
    public string sceneName;
    public int wait;
    private bool sceneChangeDispatched = false;

    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if(!audioSource.isPlaying && !sceneChangeDispatched) {
            StartCoroutine(HandleIt());
        }
	}

    private IEnumerator HandleIt()
    {
        sceneChangeDispatched = true;
        yield return new WaitForSeconds(wait);
        sceneLoader.LoadScene(sceneName);
    }
}
