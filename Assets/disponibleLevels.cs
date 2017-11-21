using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class disponibleLevels : MonoBehaviour {

	public Button[] buttons;
	public RawImage[] locket;
	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetInt("ld"));
		for (int i = 0; i < PlayerPrefs.GetInt("ld"); i ++) {
			Destroy(locket[i]);
			buttons[i].interactable = true;
		}
		print ( PlayerPrefs.GetInt("ld"));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ( PlayerPrefs.GetInt("ld"));
	}
}
