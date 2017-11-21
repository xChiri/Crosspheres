using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnTouchSkipIntro : MonoBehaviour {

	public Canvas IntroCanvas;
	public Canvas MenuCanvas;
	private bool touched;
	// Use this for initialization
	void Start () {
		touched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetTouch (0).phase == TouchPhase.Began && touched == false) {
			IntroCanvas.gameObject.SetActive(false);
			MenuCanvas.gameObject.SetActive(true);
			touched = true;
		}
	}
}
