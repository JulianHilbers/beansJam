using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score = 0;

	// Update is called once per frame
	void Update () {
        score++;
        gameObject.GetComponent<Text>().text = score + " m";	
	}
}
