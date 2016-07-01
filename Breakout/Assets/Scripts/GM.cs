using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	//static variable because we're going to access it via the class, not via an instance of the class
	//will be accessible from our other scripts [we can then get values like 'bricks' from Brick] from our game manager 
	//in a much easier fashion
	//singleton pattern: only one instance of the Game Manager available
	public static GM instance = null;

	private GameObject clonePaddle; 


	// Use this for objects to be instantiated before Start function 
	void Awake () {
		//enforce singleton pattern
			//do we have a Game Manager yet? 
		if (instance == null) 
			instance = this; 
	
		//ensures that you don't have two copies of your Game Manager
		else if (instance != this)
			Destroy (gameObject);

		Setup (); 

	}

	public void Setup() {
		//Quaternion.identity means no rotation
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject; 
		Instantiate (bricksPrefab, transform.position, Quaternion.identity); 
	}

	//just writing void means you're writing a private function
	void CheckGameOver() {
		if (bricks < 1) {
			youWon.SetActive (true);
			Time.timeScale = .25f;
			//allow you to call a function with a delay
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay); 
		}
			
	}

	void Reset () {
		Time.timeScale = 1;
		//used to load scenes
		//all loadedlevel is is the last loaded level; only one scene so you're reloading the level
		Application.LoadLevel(Application.loadedLevel);
	}

	//will be accessed from other parts of the game
	public void LoseLife() {
		lives--;
		livesText.text = "Lives: " + lives; 
		//Clones the original object and returns the clone
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver(); 
	}

	void SetupPaddle() {
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick() {
		bricks--;
		CheckGameOver ();
	}
}
