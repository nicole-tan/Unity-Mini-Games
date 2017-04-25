using UnityEngine;
using System.Collections;

/**
 * DeadZone is a class representing the floor/water of the Breakout game.
 */

public class DeadZone : MonoBehaviour {

	//OnTriggerEnter(Collider col) will call the LoseLife function when the ball collides with the water.
	void OnTriggerEnter(Collider col) {
		GM.instance.LoseLife ();
	}
}
