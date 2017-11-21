using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CASquaresFading : MonoBehaviour{

	public CanvasGroup canvas;
	public CanvasGroup croospheresCanvas;
	public Canvas MenuCanvas;
	private float timeBetweenFades;
	private float timeCrosspheresCanvas;
	private bool ok;
	private float exitingcanvases;

	void Start(){
		timeCrosspheresCanvas = 4.0f;
		timeBetweenFades = 1.0f;
		ok = false;
		exitingcanvases = 16.0f;
		MenuCanvas.gameObject.SetActive (false);
	}

	void FixedUpdate() {
		exitingcanvases -= Time.deltaTime;
		if (exitingcanvases <= 0.0f) {
			canvas.gameObject.SetActive(false);
			croospheresCanvas.gameObject.SetActive(false);
			MenuCanvas.gameObject.SetActive(true);
		}
		if (canvas.alpha <= 0.98f) {
		
			if (canvas.alpha < 0.4f)
				canvas.alpha += 0.002f;
			else if (canvas.alpha >= 0.3 && canvas.alpha < 1)
				canvas.alpha += 0.005f;

		}

		if (canvas.alpha >= 1.0f && timeBetweenFades > 0.0f)
			timeBetweenFades -= Time.deltaTime;

		if (timeBetweenFades <= 0.0f && canvas.alpha >= 0.0f)
			canvas.alpha -= 0.01f;

		if(timeCrosspheresCanvas > 0.0f)
		timeCrosspheresCanvas -= Time.deltaTime;

		if (timeCrosspheresCanvas <= 0.0f) {
			
			if (croospheresCanvas.alpha < 0.4f)
				croospheresCanvas.alpha += 0.002f;
			
			else if (croospheresCanvas.alpha >= 0.3f && croospheresCanvas.alpha < 1.0f)
				croospheresCanvas.alpha += 0.005f;
			
			else if (croospheresCanvas.alpha >= 1.0f)
				croospheresCanvas.alpha = 1.0f;
			
			if (croospheresCanvas.alpha >= 1.0f && timeBetweenFades > 0.0f)
				timeBetweenFades -= Time.deltaTime;
			
			if(croospheresCanvas.alpha == 1)
				ok = true;
			
			if(timeBetweenFades <= 0.0f && canvas.alpha <= 0.0f && ok == true)
				croospheresCanvas.alpha -= 0.02f;
		}
	}

}