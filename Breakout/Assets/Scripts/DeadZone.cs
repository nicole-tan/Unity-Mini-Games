using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		//call LoseLife function when the ball collides with the water 
		GM.instance.LoseLife ();
	}
}
