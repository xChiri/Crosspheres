using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class currentScoreText : MonoBehaviour {
	
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "Your score is " + PlayerPrefs.GetInt("currentScore").ToString () + " .";
		if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt ("Highscore")) {
			PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("currentScore"));
			PlayerPrefs.Save();
		}
		PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Your score is " + PlayerPrefs.GetInt("currentScore").ToString () + " .";
	}
}
