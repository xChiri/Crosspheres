using UnityEngine;
using System.Collections;

public class TutorialScaler : MonoBehaviour {

	
	float x;
	float y;
	// Use this for initialization
	void Start () {
		x = 100 / Screen.width;
		y = 100 / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (x);
		transform.localScale = new Vector3(Screen.width / 300, Screen.height/400, 1.0f);
	}
}
