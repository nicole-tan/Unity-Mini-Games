using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	//Ball is a child of Paddle because you want it to follow Paddle before Start

	public float ballInitialVelocity = 600f;
	//Rigidbody allows for control of an object's position through physics simulation
		//needed so you can set isKinematic to false later
	private Rigidbody rb;
	private bool ballInPlay;

	// Called before Start () function
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Fire1 is left mouse key
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) {
			//unparent the ball from the ball so it can fly off 
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
