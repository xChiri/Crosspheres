using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DotsAppearance : MonoBehaviour {

	public Text dotsText;
	private float timer;
	private float timeSaver = 0.8f;
	private int count;
	// Use this for initialization
	void Start () {
		timer = timeSaver;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f && count % 6 == 0) {
			dotsText.text =  " ";
			count ++;
			timer = timeSaver;
		}
		if (timer <= 0.0f && count % 6 == 1) {
			dotsText.text =  ".";
			count ++;
			timer = timeSaver;
		}
		if (timer <= 0.0f && count % 6 == 2) {
			dotsText.text = "..";
			count ++;
			timer = timeSaver;
		}
		if (timer <= 0.0f && count % 6 == 3) {
			dotsText.text = "...";
			count += 1;
			timer = timeSaver;
		}
		if (timer <= 0.0f && count % 6 == 4) {
			dotsText.text = "..";
			count ++;
			timer = timeSaver;
		}
		if (timer <= 0.0f && count % 6 == 5) {
			dotsText.text =  ".";
			count ++;
			timer = timeSaver;
		}
	}
}
