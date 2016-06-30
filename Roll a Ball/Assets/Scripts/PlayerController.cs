using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	//variable will show up in inspector because it is public
	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	//Check every frame for player input
	//Apply input to PlayerGame object every frame as movement

	//Update called before rendering a frame
	//where most game code goes
	void Update () {
		
	}

	//Called before performing Physics operations
	void FixedUpdate () {
		//grabs input of player aka horizontal and vertical movements through keyboard
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) {
			winText.text = "You Win!";
		}
	}


}
