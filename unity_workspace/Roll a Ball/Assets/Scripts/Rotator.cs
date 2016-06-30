using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	//Update is called once per frame
	void Update () {
		//don't want to SET transform rotation, but instead
		//rotate the transform
		//multiply by Time.deltaTime so it's independent of frame rate
		transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
