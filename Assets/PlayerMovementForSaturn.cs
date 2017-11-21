using UnityEngine;
using System.Collections;

public class PlayerMovementForSaturn : MonoBehaviour {
	
	private Rigidbody rb;
	public float speed;
	public Transform SaturnPosition;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


		float distance = Vector3.Distance (transform.position, SaturnPosition.position);

		// if(distance < 30)
			rb.AddForce (movement * speed);

		Debug.Log (distance);
		
	}
}
/* for android 
 * void FixedUpdate(){
         Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, 0.0f);
         rigidbody.velocity = movement * speed;
     }*/
