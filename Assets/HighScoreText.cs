using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "Highscore " + PlayerPrefs.GetInt ("Highscore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Highscore " + PlayerPrefs.GetInt ("Highscore").ToString();
	}
}
