using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCounter : MonoBehaviour {


	public Text countText; // textul care randeaza scorul
	public int count; // scorul
	private int cubeColor; // culoarea cubului
	public int setLevelScore; // the goal score
	private bool isWalled; // tocmai ne-am lovit de un perete care ne-a dus la 0
	public bool winGame; // daca am terminat nivelul
	public GameObject portal; // portalul
	public Canvas canvasScorer; // Canvas-ul care contine scorul si legenda 
	public Canvas winGameCanvas; // Canvas-ul care contine imaginea "Congratulations"
	private float countdown; // numaratoarea de la terminarea nivelului pana la incarcarea noii scene de selectare a nivelului urmator
	public GameObject loadingImage; // imaginea din timpul incarcarii unei scene
	public AudioSource hitted; // sunetul la lovirea cu un perete
	public Slider hittedSLider; // slider-ul SFX
	public GameObject col;
	private float t = 1.0f;
 	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();
		cubeColor = 0;
		winGame = false;
		countdown = 7.0f;
		col.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		hitted.volume = hittedSLider.value;
		if (winGame == true) { // daca am terminat nivelul
			if(Application.loadedLevelName == "Level 1" && PlayerPrefs.GetInt("Level 1") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 2);
				PlayerPrefs.SetInt("ld", 2);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 1", 1);
			}
			if(Application.loadedLevelName == "Level 2" && PlayerPrefs.GetInt ("Level 2") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 4);
				PlayerPrefs.SetInt("ld", 3);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 2", 1);
			}
			if(Application.loadedLevelName == "Level 3" && PlayerPrefs.GetInt ("Level 3") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 6);
				PlayerPrefs.SetInt("ld", 4);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 3", 1);
			}
			if(Application.loadedLevelName == "Level 4" && PlayerPrefs.GetInt ("Level 4") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 8);
				PlayerPrefs.SetInt("ld", 5);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 4", 1);
			}
			if(Application.loadedLevelName == "Level 5" && PlayerPrefs.GetInt ("Level 5") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 10);
				PlayerPrefs.SetInt("ld", 6);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 5", 1);
			}
			if(Application.loadedLevelName == "Level 6" && PlayerPrefs.GetInt ("Level 6") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 12);
				PlayerPrefs.SetInt("ld", 7);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 6", 1);
			}
			if(Application.loadedLevelName == "Level 7" && PlayerPrefs.GetInt ("Level 7") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 14);
				PlayerPrefs.SetInt("ld", 8);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 7", 1);
			}
			if(Application.loadedLevelName == "Level 8" && PlayerPrefs.GetInt ("Level 8") == 0){
				PlayerPrefs.SetInt("unlockedSpheres", 18);
				PlayerPrefs.SetInt("ld", 9);
				PlayerPrefs.Save ();
				PlayerPrefs.SetInt ("Level 8", 1);
			}
			t -= Time.deltaTime;
			if (t <= 0.0f)
				col.SetActive (true);
			portal.transform.Translate (Vector3.up * Time.deltaTime); // portalul se ridica
			countdown -= Time.deltaTime; // timp de 7 secunde
			canvasScorer.gameObject.SetActive(false); // dezactivam Canvas-ul cu informatiile despre nivelul tocmai terminat
			winGameCanvas.gameObject.SetActive(true); // incarcam Canvas-ul cu imaginea "Congratulations"
		}
		if (countdown <= 0) { // daca au trecut cele 7 secunde
			loadingImage.SetActive(true);  // activam imaginea de incarcare dintre scena precedenta si scena de urmeaza sa fie incarcata
			Application.LoadLevel ("LevelSelection"); // incarcam scena de selectie a nivelului urmator
		}
	}
	void OnCollisionEnter(Collision other){ // la coliziunea cu:
		if (other.gameObject.name == "SecretPortal" && count == setLevelScore) { // portalul
			winGame = true;
			//timePortal -= Time.deltaTime;

		}
		if (other.gameObject.CompareTag ("Green") && (cubeColor!=1||isWalled==true)) { // un cub verde
			hitted.Play ();
			count += 3;
			cubeColor=1;
			isWalled = false;
		}
		if (other.gameObject.CompareTag ("Yellow") && (cubeColor != 2||isWalled==true)) { // un cub galben
			hitted.Play ();
			count += 5;
			cubeColor = 2;
			isWalled = false;
		}
		if (other.gameObject.CompareTag ("Blue") && (cubeColor != 3||isWalled==true)) { // un cub albastru
			hitted.Play ();
			count -= 2;
			cubeColor=3;
			isWalled = false;
		}
		if (other.gameObject.CompareTag ("Violet") && (cubeColor != 4||isWalled==true)) { // un cub violet
			hitted.Play ();
			count -= 7;
			cubeColor=4;
			isWalled = false;
		}
		if (other.gameObject.CompareTag ("Black") && (cubeColor != 5||isWalled==true)) { // un cub negru
			hitted.Play ();
			count += 10;
			cubeColor=5;
			isWalled = false;
		}
		if (other.gameObject.CompareTag ("Labirinth Wall")) { // un perete ce ne duce la 0
			hitted.Play ();
			count = 0;
			isWalled = true;
		}
		SetCountText ();

	}

	void SetCountText(){ // c++ atoi 
		countText.text = count.ToString ();
	}
}
