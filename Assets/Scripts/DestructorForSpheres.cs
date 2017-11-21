using UnityEngine;
using System.Collections;

public class DestructorForSpheres : MonoBehaviour {

	private GameObject[] x;
	private GameObject y;
	// Use this for initialization
	void Start () {
		if(x == null)
			x = GameObject.FindGameObjectsWithTag ("Ball");
		//for (int i = 0; i < x.Length + 1; i ++)
		//	Destroy (x [i].gameObject);
		foreach (GameObject ball in x)
			Destroy (ball);
		y = GameObject.FindGameObjectWithTag ("SpheresManager");
		Destroy (y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
