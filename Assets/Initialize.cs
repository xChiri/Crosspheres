using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

	// Use this for initialization
	void Start () {


		if (PlayerPrefs.GetInt ("started") == 0) {
			PlayerPrefs.SetInt ("unlockedSpheres", 0);
			PlayerPrefs.SetInt ("ld", 1);
			PlayerPrefs.Save ();

			PlayerPrefs.SetInt ("Level 1", 0);
			PlayerPrefs.SetInt ("Level 2", 0);
			PlayerPrefs.SetInt ("Level 3", 0);
			PlayerPrefs.SetInt ("Level 4", 0);
			PlayerPrefs.SetInt ("Level 5", 0);
			PlayerPrefs.SetInt ("Level 6", 0);
			PlayerPrefs.SetInt ("Level 7", 0);
			PlayerPrefs.SetInt ("Level 8", 0);
			PlayerPrefs.SetInt ("Level 9", 0);

			PlayerPrefs.SetInt("started", 1);
			PlayerPrefs.Save();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
