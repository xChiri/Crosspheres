using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed;
	private Rigidbody rb;
	private float InitialAccelerometerOnX;
	
	void Start(){
		rb = GetComponent<Rigidbody> ();
		DisableAutoRotation ();
		InitialAccelerometerOnX = Input.acceleration.y;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	void FixedUpdate () 
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		/*Vector3 movement = new Vector3 (Input.acceleration.x , 0.0f, -Input.acceleration.z/2 );
		//rb.velocity = movement * speed;
		rb.AddForce (movement * speed, ForceMode.Force);
		print (movement);*/
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.z = Input.acceleration.y + 0.5f;
		rb.AddForce (dir * speed, ForceMode.Force);
	}
	
	void DisableAutoRotation(){
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	/*private Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}*/
}
/* for android 
 * void FixedUpdate(){
         Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, 0.0f);
         rigidbody.velocity = movement * speed;
     }*/ 