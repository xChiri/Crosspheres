using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour {
	
	public void pressButton(string x){
		Application.LoadLevel (x);
	}

	public void quit(){
			Application.Quit();
	}
}
