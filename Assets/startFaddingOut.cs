using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startFaddingOut : MonoBehaviour {

	public CanvasGroup start;
	public Canvas starter;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0.0f)
			start.alpha -= 0.01f;
		if (start.alpha <= 0.0f) {
			starter.enabled = false;
		}

	}
}
