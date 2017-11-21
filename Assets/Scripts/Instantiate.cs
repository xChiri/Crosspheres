using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {

	public GameObject Sphere;
	private Vector3 offset;
	private bool isInLevel;
	public GameObject sf;
	//private bool isInLevel;
	// Use this for initialization
	void Start () {
	if (Application.loadedLevelName == "Level 3" || Application.loadedLevelName == "Level 4")
			isInLevel = true;
		else
			isInLevel = false;

		if(isInLevel == true)
		{
		Sphere = GameObject.FindGameObjectWithTag ("Ball");
		if(Application.loadedLevelName == "Level 3")
			Sphere.transform.position = new Vector3(0.57f, 0.5f, 1.0f);
		if(Application.loadedLevelName == "Level 4")
			Sphere.transform.position = new Vector3(0.0f, 0.7f, -17.35f);
	//	Sphere.transform.localScale = transform.localScale;
		offset = Sphere.transform.position - transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isInLevel == true) {
			Sphere.transform.position = transform.position + offset;
			Sphere.transform.rotation = transform.rotation;
		}
		//Instantiate (Sphere, new Vector3 (0, 0.5f, 0), transform.rotation);
		//0,11084f, 0,202f, -6,8005
	}
}
