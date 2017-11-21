using UnityEngine;
using System.Collections;

public class inGamePauseButtons : MonoBehaviour {

	public void gameButtons(string x){
		Application.LoadLevel (x);
	}

	public void ExitGame(){
		Application.Quit ();
	}

}
