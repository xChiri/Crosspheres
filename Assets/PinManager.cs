using UnityEngine;
using System.Collections;

public class PinManager : MonoBehaviour {

	public Transform centerOfMass;
	
	private Vector3 initialPosition;
	
	public Rigidbody rigidbodyComponent;

	public GameObject activator;

	public GameObject scor;

	public GameObject MainBall;
	
	// Use this for initialization
	void Awake () 
	{
		rigidbodyComponent = GetComponent<Rigidbody> ();
		
		initialPosition = transform.position;
		
		rigidbodyComponent.centerOfMass = centerOfMass.localPosition;
	}
	
	void Start()
	{
		Reset();
	}
	
	private void Reset()
	{
		float dist = Vector3.Distance (transform.position, initialPosition);
		//Debug.Log (dist);
		if (dist >= 0.5f)
			scor.GetComponent<ScorerBowling> ().score ++;

		transform.eulerAngles = new Vector3 (0, 0, 0);
		transform.position = initialPosition;
		
		transform.rotation = Quaternion.identity;
		
		rigidbodyComponent.velocity = Vector3.zero;
		rigidbodyComponent.angularVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (activator.gameObject.activeSelf == true)
		{
			Reset();
		}
		if (MainBall.GetComponent<PushingBawll> ().released == false) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			rigidbodyComponent.velocity = Vector3.zero;
			rigidbodyComponent.angularVelocity = Vector3.zero;
		}
	}
}
