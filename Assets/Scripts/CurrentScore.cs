using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {

    public GameStats gamestats;

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        text.text = gamestats.GetCurrentScore() + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
