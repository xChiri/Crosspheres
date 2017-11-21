using UnityEngine;
using System.Collections;

public class selectLevel : MonoBehaviour {

	public void SelectLevel(string x){
		Application.LoadLevel (x);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
