using UnityEngine;
using System.Collections;

public class PushingBawll : MonoBehaviour {

	private Vector3 initialMousePosition;
	private Rigidbody rb;
	public bool released;
	private Vector3 InitialMainBallPosition;

	private float timer = 4.0f;
	private bool hittedPop;

	public GameObject[] Spheres;
	private int currentball = 0;

	private bool timergone = false;
	public GameObject activator;

	public Canvas finalScore;

	public Canvas PressSpace;
	
	public GameObject Paused;

	private float TimerAfterPause = 0.0f;
	private bool LastValueOfPaused;
	private bool changed = false;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		finalScore.gameObject.SetActive (false);

		Spheres [currentball].transform.position = new Vector3 (0, 1, -9.67f);
	//	Spheres [currentball].transform.localScale /= 2;

		for (int i = currentball + 1; i < 20; i ++) {
			Spheres[i].SetActive(false);
		}
		for (int i = PlayerPrefs.GetInt("unlockedSpheres") + 2; i < 20; i ++) {
			Destroy(Spheres[i]);
		}

		activator.gameObject.SetActive (false);

		InitialMainBallPosition = transform.position;

		PressSpace.gameObject.SetActive (false);

		DisableAutoRotation ();
	}



	void Update () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		Debug.Log ( released);

		if (LastValueOfPaused == true && Paused.activeSelf == false && changed == false) {
			TimerAfterPause = 0.5f;
			changed = true;
		}
		if (changed == true) {
			TimerAfterPause -= Time.deltaTime;
		}
	//	Debug.Log (released);
	//	if (Paused.activeSelf == false) {
		if (Input.GetMouseButtonDown (0)) {
				initialMousePosition = Input.mousePosition;
			}

		if (Input.GetMouseButtonUp (0) && Paused.activeSelf == false && TimerAfterPause <= 0.0f) {
				float x;
				x = Mathf.Abs((Input.mousePosition - initialMousePosition).y )* 25 / Screen.height;
				Launch (Mathf.Abs (x));
				TimerAfterPause = 0;
				changed = false;
			}

			if (released == false) {
			float moveHorizontal = Input.acceleration.x; 
			rb.AddForce (moveHorizontal, 0.0f, 0.0f);
		} 

			if (hittedPop == true) {

				timer -= Time.deltaTime;

				if (timer <= 0.0f) 
				{
					timergone = true; 
					PressSpace.gameObject.SetActive(true);
				}

			}

			if(currentball == PlayerPrefs.GetInt("unlockedSpheres") + 1){
				released = true;
			}
			if ((currentball == PlayerPrefs.GetInt("unlockedSpheres") + 1) && Input.GetTouch(0).phase == TouchPhase.Began && timergone == true) {
				finalScore.gameObject.SetActive (true);
				PressSpace.gameObject.SetActive (false);
			}

			/*float dist = Vector3.Distance(InitialMainBallPosition,transform.position);
		print (dist);
			if (dist <= 0.1f) {
			released = false;
		} else {
			released = true;
		}*/
		if (Mathf.Abs (InitialMainBallPosition.z - transform.position.z) <= 0.1f) {
			released = false;
		} else {
			released = true;
		}
			if (timergone == true && Input.GetTouch(0).phase == TouchPhase.Began && (currentball < 2 + PlayerPrefs.GetInt("unlockedSpheres"))) {
					activator.gameObject.SetActive (true);
					timergone = false;
					timer = 4.0f;
					released = false;
					rb.velocity = Vector3.zero;
					rb.angularVelocity = Vector3.zero;
					hittedPop = false;
					Destroy (Spheres [currentball]);
					currentball ++;
					Spheres [currentball].SetActive (true);
					transform.position = new Vector3 (0, 1, -9.67f);
					PressSpace.gameObject.SetActive(false);
					//activator.gameObject.SetActive (false);
				} else
					activator.gameObject.SetActive (false);
		LastValueOfPaused = Paused.activeSelf;
		/*} else
			if(released == false)
			{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;


		}*/
	//	if (Paused.activeSelf == false) {
	//		released = false;

	}

	void Launch(float LaunchPower){
		if (released == false ) {
			rb.AddForce (0, 0, LaunchPower, ForceMode.Impulse);
			released = true;
		}
	}
	

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Pop" && hittedPop == false) {
			hittedPop = true;
		}
	}

	void DisableAutoRotation(){
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
}
