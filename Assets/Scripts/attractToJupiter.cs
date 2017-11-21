using UnityEngine;
using System.Collections;

public class attractToJupiter : MonoBehaviour {

	//get the offset between the objects
	public GameObject attractedTo;
	public float strengthOfAttraction = 5.0f;
	Vector3 offset;
	Rigidbody rb;

	void Start(){
		offset = attractedTo.transform.position - transform.position;
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		offset = attractedTo.transform.position - transform.position;
		//get the squared distance between the objects
		float magsqr = offset.sqrMagnitude;
		
		//check distance is more than 0 (to avoid division by 0) and then apply a gravitational force to the object
		//note the force is applied as an acceleration, as acceleration created by gravity is independent of the mass of the object
		if(magsqr > 0.0001f)
			rb.AddForce(strengthOfAttraction * offset.normalized / magsqr, ForceMode.Acceleration);
		
	}

}
