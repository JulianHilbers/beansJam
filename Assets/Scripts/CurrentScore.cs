using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {

    public GameStats gamestats;

    public Text text;

	// Use this for initialization
	void Start () {
        //TODO
        Debug.Log("currentScore: " + gamestats.GetCurrentScore());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
