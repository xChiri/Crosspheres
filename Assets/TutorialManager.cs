using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

	public GameObject Sphere;
	public RawImage AchieveTheGoal;
	public RawImage GoOnPortal;
	public RawImage AvoidBlackWalls;
	// Use this for initialization
	void Start () {
		AchieveTheGoal.gameObject.SetActive(true);
		GoOnPortal.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Sphere.GetComponent<PlayerCounter> ().winGame == false) {
			if (Sphere.GetComponent<PlayerCounter> ().count == Sphere.GetComponent<PlayerCounter> ().setLevelScore) {
				AchieveTheGoal.gameObject.SetActive (false);
				GoOnPortal.gameObject.SetActive (true);
			} else {
				AchieveTheGoal.gameObject.SetActive (true);
				GoOnPortal.gameObject.SetActive (false);
			}
		}
		if(Sphere.GetComponent<PlayerCounter>().winGame == true){
			AchieveTheGoal.gameObject.SetActive(false);
			GoOnPortal.gameObject.SetActive(false);
			AvoidBlackWalls.gameObject.SetActive(false);
		}
	}
}
