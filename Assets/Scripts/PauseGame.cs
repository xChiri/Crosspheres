using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseGame : MonoBehaviour {
	
	private bool Pause = false;
	public Canvas PauseCanvas;
	public Canvas SettingsCanvas;
	private int nr;
	private bool inSet;
	public AudioSource bkmusic;
	public AudioSource sfxmusic;
	public Slider musicslider;
	public Slider SFXslider;
	private GameObject pausedTrans;

	void Start(){
		nr = 0;
		inSet = false;
		SettingsCanvas.gameObject.SetActive (false);
		if (Application.loadedLevelName == "Bowling") {
			pausedTrans = GameObject.FindGameObjectWithTag("Pause");
		}
	}


	void Update()
	{
		bkmusic.volume = musicslider.value/5;
		sfxmusic.volume  = SFXslider.value;
		if (Application.loadedLevelName == "Bowling") {
			pausedTrans.SetActive (Pause);
		}
		if (Pause == false) {
			Time.timeScale = 1;
			PauseCanvas.gameObject.SetActive (false);
		} else {
			Time.timeScale = 0;
			if( inSet == false)
			{
				PauseCanvas.gameObject.SetActive(true);
				SettingsCanvas.gameObject.SetActive(false);
			}
			else{
				PauseCanvas.gameObject.SetActive(false);
				SettingsCanvas.gameObject.SetActive(true);
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(inSet == false){
			nr ++;
			if(nr % 2 == 0)
				Pause = false;
			else Pause = true;
			}
			else {
				PauseCanvas.gameObject.SetActive(true);
				SettingsCanvas.gameObject.SetActive(false);
				inSet = false;
			}
		}

	}
	
	public void onResumeButon(){
		sfxmusic.Play ();
		nr ++;
		Pause = false;
	}	

	public void Settings(){
		sfxmusic.Play ();
		inSet = true;

	}

	public void backFromSettings(){
		sfxmusic.Play ();
		inSet = false;

	}

}