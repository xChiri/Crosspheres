using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScorerBowling : MonoBehaviour {

	public Text text;
	public int score;
	// Use this for initialization
	void Start () {
		score = 0;
		text.text = "Score: " + score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt ("currentScore", score);
		text.text = "Score: " + score.ToString ();
	}
}
