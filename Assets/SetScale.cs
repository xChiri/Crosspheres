using UnityEngine;
using System.Collections;

public class SetScale : MonoBehaviour {

	public int x;
	public int y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (Screen.width/x, Screen.height/y, 0.0f);	
	}
}
