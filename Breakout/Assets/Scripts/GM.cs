using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/** 
  * This class represents the Game Manager within our Breakout game. 
  */

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	//livesText is a Text element and not a GameObject element because it is shown at all times
	public Text livesText;
	public Text scoreText; 
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	/** Static variable: access via the class, not via an instance of the class
	Will be accessible from our other scripts [we can then get values like 'bricks' from Brick] from our game manager 
	more easily
	Singleton pattern: only one instance of the Game Manager available at all times **/
	public static GM instance = null;

	private GameObject clonePaddle; 


	// Awake function used for objects to be instantiated [before Start function ]
	void Awake () {
		//Enforcing of singleton pattern
			//Do we have a Game Manager yet? 
		if (instance == null) 
			instance = this; 
	
		//Ensures that you don't have two copies of your Game Manager
		else if (instance != this)
			Destroy (gameObject);

		Setup (); 

	}

	//Called once every frame 
	void Update () {
		
	}

	/** Setup() clones the paddle GameObject and bricks GameObjects and returns them
		This allows you to delete unnecessary clutter from your hierarchy
		It also allows for seamless instantiation when the game has to be restarted **/
	public void Setup() {
		//Quaternion.identity means no rotation
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject; 
		Instantiate (bricksPrefab, transform.position, Quaternion.identity); 
	}

	//Just writing void means you're writing a private function
	/** CheckGameOver() looks to see if you have either 1. Run out of bricks OR 2. Run out of lives and outputs the
		proper result **/
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

	//Reset() is used to load scenes. In this case it reloads our last level aka our only level.
	void Reset () {
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	//Public functions will be accessed from other parts of the game.
	/** LoseLife() decrements the number of lives and presents the new number on the screen. 
		It also creates clones of the deathParticles, destroys the cloned paddle, calls SetupPaddle() and 
		checks to see if the game is finished. **/
	public void LoseLife() {
		lives--;
		livesText.text = "Lives: " + lives; 
		//Clones the original object and returns the clone
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver(); 
	}

	//SetuPaddle() clones the pre-existing paddle and places it in the center position after a life is lost.
	void SetupPaddle() {
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	//DestroyBrick() decrements the number of bricks and checks to see if the game is over.
	public void DestroyBrick() {
		bricks--;
		CheckGameOver ();
	}
}
