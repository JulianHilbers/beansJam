using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour {

    public GameStats gamestats;

	void Start()
    {
        GameObject.Find("Score").GetComponent<Text>().text = gamestats.GetCurrentScore() + " m";

	}
}
