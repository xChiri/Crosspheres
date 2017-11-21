using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasketBallJumpingSphere : MonoBehaviour {

	private Vector3 InitialMousePosition;
	private Rigidbody ComponentRigidbody;

	public float VerticalForce;
	public float HorizontalForce;

	private float diagonal;

	private Vector3 LastMousePosition;
	private bool CheckedLastPosition;

	public bool InitialMousePositionCheck;
	
	public int scor = 0;
	public Text ScoreText;

	public GameObject target1;
	public GameObject target2;
	public GameObject target3;

	public Canvas finalScore;

	public Canvas PressSpace;

	private float TimerBetweenShots = 3.0f;

	public bool released;
	
	private int currentball = 0;
	[SerializeField] GameObject[] Spheres;

	public GameObject disc;

	// Use this for initialization
	void Start () {
		ComponentRigidbody = GetComponent<Rigidbody> ();
		InitialMousePositionCheck = false;
		diagonal = Mathf.Sqrt (Screen.width * Screen.width + Screen.height * Screen.height);
		CheckedLastPosition = false;
		//	Spheres [currentball].transform.localScale /= 2;
		
		for (int i = currentball + 1; i < 20; i ++) {
			Spheres[i].SetActive(false);
		}
		for (int i = PlayerPrefs.GetInt("unlockedSpheres") + 3; i < 20; i ++) {
			Destroy(Spheres[i]);
		}
		finalScore.gameObject.SetActive(false);
		PressSpace.gameObject.SetActive(false);

		DisableAutoRotation ();
	}

	
	// Update is called once per frame
	void Update () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Spheres [currentball].transform.position = transform.position;
		Spheres [currentball].transform.rotation = transform.rotation;
		ScoreText.text = "Score: " + scor.ToString ();
		if (released == false) {
			transform.position = new Vector3 (-0.137f, 4.0f, -8.0f);
			Spheres[currentball].transform.position = new Vector3 (-0.137f, 4.0f, -8.0f);
		} 
		if (released == true) {
			TimerBetweenShots -= Time.deltaTime;
		}

		if (TimerBetweenShots <= 0.0f) {
			PressSpace.gameObject.SetActive(true);
		}
		if (finalScore.gameObject.activeSelf == true) {
			PressSpace.gameObject.SetActive(false);
		}
		if (Input.GetMouseButtonUp (0) && InitialMousePositionCheck == true) {
			VerticalForce = InitialMousePosition.y - Input.mousePosition.y;
			HorizontalForce = Input.mousePosition.x - InitialMousePosition.x;
			//lansare
			Launch (VerticalForce, HorizontalForce);
			InitialMousePositionCheck = false;

		}

		if (InitialMousePositionCheck == true) {
			MoveTargets ((InitialMousePosition.y - Input.mousePosition.y) / 100, (InitialMousePosition.x - Input.mousePosition.x) / 100);
		}

		LastMousePosition = Input.mousePosition;
		CheckedLastPosition = true;
			
		if ((currentball == PlayerPrefs.GetInt ("unlockedSpheres") + 1) && Input.GetTouch(0).phase == TouchPhase.Began && TimerBetweenShots <= 0.0f) {
			finalScore.gameObject.SetActive (true);
			PressSpace.gameObject.SetActive (false);
		}

		if (released == true && TimerBetweenShots <= 0.0f && Input.GetTouch(0).phase == TouchPhase.Began && (currentball < 2 + PlayerPrefs.GetInt ("unlockedSpheres"))) {
			Reset ();
			released = false;
		}
		PlayerPrefs.SetInt("BasketballScore", scor);
	}
			

	void Launch(float V, float H){
		if (released == false) {
			ComponentRigidbody.AddForce (0, V*100/Screen.height, H*200/Screen.width, ForceMode.Impulse);
			released = true;
		}
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			InitialMousePosition = Input.mousePosition;
			InitialMousePositionCheck = true;
		}
	}

	void MoveTargets(float V, float H){
		target1.transform.position += new Vector3(0, V, 0);
		target2.transform.position += new Vector3(0, V, 0);
		target3.transform.position += new Vector3(0, V, 0);

		target1.transform.position += new Vector3(0, 0, H);
		target2.transform.position += new Vector3(0, 0, H);
		target3.transform.position += new Vector3(0, 0, H);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "ScorChecker") {
			scor ++;
			PlayerPrefs.SetInt("BasketballScore", scor);
			other.gameObject.SetActive (false);
		}
	}

	void Reset(){
		ComponentRigidbody.velocity = Vector3.zero;
		ComponentRigidbody.angularVelocity = Vector3.zero;
		TimerBetweenShots = 3.0f;
		Destroy(Spheres[currentball]);
		currentball ++;
		PressSpace.gameObject.SetActive(false);
		if (currentball < PlayerPrefs.GetInt ("unlockedSpheres") + 2) {
			Spheres [currentball].gameObject.SetActive (true);
		}
		disc.gameObject.SetActive(true);
	}

	void DisableAutoRotation(){
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

}
//http://answers.unity3d.com/questions/496234/trajectory-prediction-basketball.html
//Launch(Mathf.Abs(Vector3.Distance(InitialMousePosition ,Input.mousePosition))/10);
//cadran IV
/*if (Input.mousePosition.x > InitialMousePosition.x && Input.mousePosition.y < InitialMousePosition.y) {
				VerticalForce = InitialMousePosition.y - Input.mousePosition.y;
				HorizontalForce = Input.mousePosition.x - InitialMousePosition.x;
			}
			//cadran III
			if(Input.mousePosition.x < InitialMousePosition.x && Input.mousePosition.y < InitialMousePosition.y){
				VerticalForce = InitialMousePosition.y - Input.mousePosition.y;
				HorizontalForce = Input.mousePosition.x - InitialMousePosition.x;
			}
			//cadran II
			if(Input.mousePosition.x < InitialMousePosition.x && Input.mousePosition.y > InitialMousePosition.y){
				VerticalForce = InitialMousePosition.y - Input.mousePosition.y;
				HorizontalForce = Input.mousePosition.x - InitialMousePosition.x;
			}
			//cadran I
			if(Input.mousePosition.y > InitialMousePosition.y && Input.mousePosition.x > InitialMousePosition.x){
			//	VerticalForce = InitialMousePosition.y - Input.mousePosition.y;
				VerticalForce = 5;
				HorizontalForce = Input.mousePosition.x - InitialMousePosition.x;

				}
			//
			*/