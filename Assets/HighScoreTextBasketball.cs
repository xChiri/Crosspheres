using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreTextBasketball : MonoBehaviour {
	
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "HighscoreBasketball " + PlayerPrefs.GetInt ("HighscoreBasketball").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Your Highscore is " + PlayerPrefs.GetInt ("HighscoreBasketball").ToString();
	}
}
