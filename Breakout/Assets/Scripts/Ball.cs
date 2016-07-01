using UnityEngine;
using System.Collections;

/*
 * Bricks is a class representing the ball in our Breakout game. 
 * It is a child of Paddle because you want the ball to follow Paddle before the Start() function is called.
 */
public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;
	//Rigidbody allows for control of an object's position through physics simulation
		//needed so you can set isKinematic to false later
	private Rigidbody rb;
	private bool ballInPlay;

	// Called before Start () function
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update() is called once per frame. It checks to see that the game has not started and, if this is the case,
	//unparents the ball from the paddle so it can fly off, sets the ballInPlay bool to true, turns off 
	//isKinematic so forces can act on it, and adds the initial force so the ball will fly off. 
	void Update () {
		//Fire1 is left mouse key
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) {
			//unparent the ball from the paddle 
			transform.parent = null;
			ballInPlay = true;
			//isKinematic is turned on initially because you want to move the ball according to this script
			//now it is turned off so forces [and Physics] can act on it
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (ballInitialVelocity, ballInitialVelocity, 0));
		}
	}

	//repeated physics should go into FixedUpdate (), but, as you are only dealing with adding force once, 
	//you can leave it in Update () 
}
