using UnityEngine;
using System.Collections;

public class SpheresController : MonoBehaviour {
	
	private Vector3 outOfRange = new Vector3 (30.0f,30.0f,0.0f);
	private Vector3 originVector = new Vector3(0.0f, 1.2f, -4.9f);

	public int numberOfSpheres; // numarul de sfere = 20
	public GameObject[] Spheres; // vectorul in care tinem copiile sferele
	public int currentball; // sfera curenta
	private bool moved; // daca bila a fost pusa la pozitia initiala
	private GameObject mainBall; // pozitia sferei principale
	public bool isInLevel; // daca suntem in Playable Mode
	private Vector3 offset; // distanta de la bila principala la bila copie
	private bool scaled;
	private GameObject lockedCanvas;
	// Use this for initialization
	void Start () {
		currentball = 0; // setam bila curenta ca fiind prima
		moved = false; // la inceputul fiecarui nivel trebuia activam pozitia initiala a sferei selectate
		//for (int i = 0; i < 20; i ++)
		//	DontDestroyOnLoad (Spheres [i]); // pastram sferele in fiecare scena
		isInLevel = false; // initializam variabila daca retine faptul ca suntem in Playable Mode cu false
		scaled = false;
		if(Application.loadedLevelName == "SelectionScene"){
			lockedCanvas = GameObject.FindGameObjectWithTag("lockedCanvas");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if ((checkLevel()==true) && moved==false) { // daca suntem in Playable Mode si sfera nu a fost asezata pe pozitia ei initiala
			mainBall = GameObject.FindGameObjectWithTag("Player"); // gasim bila principala
			if(scaled == false){
				Spheres[currentball].transform.localScale /= 2; // scalam dimensiunile sferei
				scaled = true;
			}
			//in functie de nivel alegem pozitia bilei
			if(Application.loadedLevelName == "Level 1")
				Spheres[currentball].transform.position = new Vector3(0.0f, 0.5f, 1.25f); // daca suntem in primul nivelul punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 2")
				Spheres[currentball].transform.position = new Vector3(6.0f, -1.15f, -6.0f); // daca suntem in nivelul 2 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 3")
				Spheres[currentball].transform.position = new Vector3(0.0f, 0.5f, 1.25f); // daca suntem in nivelul 3 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 4")
				Spheres[currentball].transform.position = new Vector3(0.0f, 0.7f, -17.35f); // daca suntem in nivelul 4 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 5")
				Spheres[currentball].transform.position = new Vector3(-0.621f, 0.5f, -1.564f); // daca suntem in nivelul 5 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 6")
				Spheres[currentball].transform.position = new Vector3(-29.41f, 0.86f, -0.0f); // daca suntem in nivelul 6 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 7")
				Spheres[currentball].transform.position = new Vector3(-6.71f, 0.5f, -9.94f); // daca suntem in nivelul 7 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 8")
				Spheres[currentball].transform.position = new Vector3(-12.23f, 0.43f, -0.67f); // daca suntem in nivelul 8 punem bila pe pozitia de inceput
			if(Application.loadedLevelName == "Level 9")
				Spheres[currentball].transform.position = new Vector3(0.0f, 0.5f, 0.0f); // daca suntem in nivelul 9 punem bila pe pozitia de inceput
			isInLevel = true; // suntem in Playable Mode si activam variabila care retine acest fapt, punand-o pe true
			moved = true; // am pus bila pe pozitia initiala
			offset = Spheres[currentball].transform.position - mainBall.transform.position; // salvam distanta dintre sfera principala si copia sferei pe care o folosim
		}

		if (Application.loadedLevelName == "Main Menu") { //daca  suntem in meniul principal
			isInLevel = false;
			moved = false;
		}

		if (Application.loadedLevelName == "SelectionScene") {
			if(currentball < PlayerPrefs.GetInt("unlockedSpheres") + 2)
				lockedCanvas.SetActive(false);
			else lockedCanvas.SetActive(true);
		}

		if (Application.loadedLevelName == "LevelSelection") { // daca suntem in meniul de selectie a nivelului
			isInLevel = false;
			moved = false;
		}

		if (isInLevel == true) { // daca suntem in Playable Mode
			Spheres[currentball].transform.position = mainBall.transform.position + offset; // la fiecare frame modificam pozitia copiei sferei pe care o folosim in functie de pozitia bilei principale
			Spheres[currentball].transform.rotation = mainBall.transform.rotation; // la fiecare frame modificam rotatia copiei sferei pe care o folosim astfel incat sa fie identica cu cea a sferei principale
		}

	}

	public void OnLeftButtonPressed(){ // daca suntem in meniul de selectie a sferei si s-a apasat butonul alb din stanga
		if (currentball > 0) { // cat timp nu am ajuns la ultima sfera
			Spheres[currentball].transform.position= outOfRange;
			Spheres[currentball -1].transform.position = originVector;
			currentball --;
		}
	}

	public void OnRightButtonPressed(){ // daca suntem in meniul de selectie a sferei si s-a apasat butonul alb din dreapta
		if (currentball < numberOfSpheres-1) { // cat timp nu am ajuns la ultima sfera
			Spheres[currentball].transform.position= outOfRange;
			Spheres[currentball + 1].transform.position = originVector;
			currentball ++;
		}
	}

	public void SelectButtonPressed(){
	//for (int i = 0; i < 20; i ++)
		if(currentball < PlayerPrefs.GetInt("unlockedSpheres") + 2) 
		{
			DontDestroyOnLoad (Spheres [currentball]);
			DontDestroyOnLoad (transform.gameObject);
			Application.LoadLevel ("LevelSelection");
		}
	}

	public void BackButtonPressed(){
		Application.LoadLevel ("Main Menu");
	}	

	private bool checkLevel(){
		if(Application.loadedLevel >= 7 &&  Application.loadedLevel <= 15)
			return true;
		else
			return false;
	}
}

