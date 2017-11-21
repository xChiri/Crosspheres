using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionSet : MonoBehaviour {

	Resolution[] resolutions;

	[SerializeField] Transform menuPanel;
	[SerializeField] GameObject buttonPrefab;
	[SerializeField] Toggle setfull;
	private bool isfull;
	// Use this for initialization
	void Start () {
		if (Screen.fullScreen == true) {
			isfull = true;
			setfull.isOn = true;
		} else {
			isfull = false;
			setfull.isOn = false;
		}
		resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i ++) {
			GameObject button = (GameObject)Instantiate (buttonPrefab);
			button.GetComponentInChildren<Text>().text = ResToString(resolutions[i]);
			int index = i;
			button.GetComponent<Button>().onClick.AddListener(
				() => {SetResolution (index);}
			);
			button.transform.parent = menuPanel;
		}
	}

	void SetResolution (int index){
		Screen.SetResolution (resolutions[index].width, resolutions[index].height, setfull.isOn);
	}

	string ResToString (Resolution res){
		return res.width + "x" + res.height;
	}

}
