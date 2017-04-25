using UnityEngine;
using System.Collections;

/*
 * Bricks is a class representing the Bricks prefab in our Breakout game. 
 */

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;

	//OnCollisionEnter(Collision other) spawns particles by cloning them, calls the DestroyBrick() function
	//and removes the current brick from the screen once the ball hits the brick.
	void OnCollisionEnter (Collision other) {
		Instantiate(brickParticle, transform.position, Quaternion.identity);
		//can call DestroyBrick function from Bricks script because we set up a static instance of GM
		GM.instance.DestroyBrick();
		Destroy (gameObject);
	}
}
