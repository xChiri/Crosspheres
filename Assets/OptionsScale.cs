using UnityEngine;
using System.Collections;

public class OptionsScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(Screen.width/600, Screen.height/300, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(Screen.width/600, Screen.height/300, 1.0f);
	}
}
