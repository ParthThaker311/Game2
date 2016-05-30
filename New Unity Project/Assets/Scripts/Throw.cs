using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb2d;
	private Vector3 movement;
	public GameObject target;
	private bool moveRight = true;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		if (mousePos.x < rb2d.position.x) {
			transform.Rotate (Vector3.forward * -90);
			moveRight = false;
		} else {
			transform.Rotate (Vector3.forward * 90);
		}
		movement.x = mousePos.x - rb2d.position.x;
		movement.y = mousePos.y - rb2d.position.y;
		movement.Normalize ();
		rb2d.velocity = movement*speed;
		this.transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(this.transform.right, movement.normalized)));


		//rb2d.transform.LookAt (mousePos);
	}

	// Update is called once per frame
	void Update () {
		if (moveRight) {
			this.transform.Rotate (new Vector3 (0, 0, 360.0f - Vector3.Angle (this.transform.right, rb2d.velocity.normalized)));
		} else {
			this.transform.Rotate (new Vector3 (0, 0, -360.0f + Vector3.Angle (this.transform.right, rb2d.velocity.normalized)));
		}
	}

}
