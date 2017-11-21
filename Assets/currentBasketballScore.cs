using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class currentBasketballScore : MonoBehaviour {

	public Text currentScore;

	// Use this for initialization
	void Start () {
		currentScore.text = "Your score is " + PlayerPrefs.GetInt ("BasketballScore").ToString () + " .";
		if (PlayerPrefs.GetInt("BasketballScore") > PlayerPrefs.GetInt ("HighscoreBasketball")) {
			PlayerPrefs.SetInt("HighscoreBasketball", PlayerPrefs.GetInt("BasketballScore"));
			PlayerPrefs.Save();
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentScore.text = "Your score is " + PlayerPrefs.GetInt ("BasketballScore").ToString () + " .";
	}
}
