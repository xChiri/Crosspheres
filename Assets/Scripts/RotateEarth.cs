using UnityEngine;
using System.Collections;

public class RotateEarth : MonoBehaviour {

	private float earthMovementSpeed;
	private float moveSpeed;
	private float timeCounter;
	// Use this for initialization
	void Start () {
		moveSpeed = 0.1f;
		earthMovementSpeed = 0.5f;
		timeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(-moveSpeed*Time.deltaTime,0,0);
		if (timeCounter <= 100) {
			if (earthMovementSpeed >= 0) {
				earthMovementSpeed -= Time.deltaTime;
			} else {
				moveSpeed += 0.05f;
				earthMovementSpeed = 0.5f;
				timeCounter++;
			}
		}
	}
}
