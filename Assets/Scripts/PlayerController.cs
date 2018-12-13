using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public float jumpForce;
	public float distToGround = 0.5f;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		Debug.Log (isGrounded());
		if (Input.GetKey(KeyCode.Space)) {
			rb.AddForce (0, 11.0f, 0);
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal*-1, 0.0f, moveVertical*-1);
		//Vector3 jump = new Vector3 (0.0f, 2.0f, 0.0f);

		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
	bool isGrounded() {
		return Physics.Raycast (transform.position, Vector3.down, distToGround);
	}
}
