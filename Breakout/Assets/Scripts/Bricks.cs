using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;

	void OnCollisionEnter (Collision other) {
		//spawn our particles
		Instantiate(brickParticle, transform.position, Quaternion.identity);
		//can call DestroyBrick function from Bricks script because we set up a static instance of GM
		GM.instance.DestroyBrick();
		//remove brick from screen 
		Destroy (gameObject);
	}
}
