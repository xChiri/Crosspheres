using UnityEngine;
using System.Collections;

public class PortalClimbing : MonoBehaviour {

	public GameObject portal;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = portal.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = portal.transform.position - offset;
	}
}
