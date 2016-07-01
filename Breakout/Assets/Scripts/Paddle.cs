using UnityEngine;
using System.Collections;

/*
 * Paddle is a class representing the Paddle in our Breakout game. 
 */

public class Paddle : MonoBehaviour {
	//isKinematic is turned on when you want to adjust an object using the script
		//turned off when you want to use Physics
	//Can be adjusted in the editor because it's public
	public float paddleSpeed = 1f;

	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);


	// Update is called once per frame. It updates the xPosition of our Paddle according to keyboard input. 
	void Update () {
		//transform.position.x is the current position of x 
		//x position transformed of the paddle + input of the left and right arrows on keyboard
			//the position is determined by how much the arrows have been pressed and how fast the paddle moved
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);

		//Clamp limits a number between 2 values --> (xPos, min, max)
		playerPos = new Vector3(Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0);
		transform.position = playerPos;
	}
}



