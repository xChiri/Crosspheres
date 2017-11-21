using UnityEngine;
using System.Collections;

public class screenlandscapeleft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DisableAutoRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	void DisableAutoRotation(){
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}
