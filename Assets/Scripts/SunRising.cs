using UnityEngine;
using System.Collections;

public class SunRising : MonoBehaviour {

	public GameObject sun;
	public Light risingLight;
	private float time;
	// Use this for initialization
	void Start () {
		time = 11.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (time >= 0.0f) {
			sun.transform.Translate (Vector3.up * Time.deltaTime * 2);
			time -= Time.deltaTime;
		}
		if(risingLight.intensity <= 1)
		risingLight.intensity += 0.001f;
	}
}
