using UnityEngine;
using System.Collections;

public class RotateEarth45 : MonoBehaviour {

	private float moveSpeedVertical;
	private float moveSPeedHorizontal;
	// Use this for initialization
	void Start () {
		moveSPeedHorizontal = 18.0f;
		moveSpeedVertical = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(-moveSpeedVertical*Time.deltaTime,0,moveSPeedHorizontal*Time.deltaTime);
	}
}
