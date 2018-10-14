using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    public List<string> devs;
    public List<string> thanks;
    public List<string> graphics;
    public List<string> sounds;
    private string highlightColor = "#ff530d";
    private Text textObj;
    public float speed = 3.5f;

	void Start () {
        string credits = "<b><color="+ highlightColor + "><size=80>CREDITS</size></color></b>\n\n";

        credits += "<b><color=" + highlightColor + ">Sound Designer</color></b>\n";
        sounds.ForEach((string name) => {
            credits += name + "\n";
        });

        credits += "\n\n <b><color=" + highlightColor + ">Pixel Schubser</color></b>\n";
        graphics.ForEach((string name) => {
            credits += name + "\n";
        });

        credits += "\n\n <b><color=" + highlightColor + ">Developers</color></b>\n";
        devs.ForEach((string name) => {
            credits += name + "\n";
        });

        credits += "\n\n <b><color=" + highlightColor + ">Thanks to</color></b>\n";
        thanks.ForEach((string name) => {
            credits += name + ", ";
        });
        credits += "...";

        textObj = GetComponent<Text>();
        textObj.text = credits;
	}
	
	// Update is called once per frame
	public void FixedUpdate() {
        if (transform.localPosition.y < 3000) {
            textObj.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
	}
}
