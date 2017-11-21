using UnityEngine;
using System.Collections;

public class FollowMainBall : MonoBehaviour {

	private Vector3 offset;
	public GameObject MainBall;

	// Use this for initialization
	void Start () {
		offset = MainBall.transform.position - transform.position;
		transform.localScale /= 2;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = MainBall.transform.position - offset;
		transform.rotation = MainBall.transform.rotation;
	}
}
