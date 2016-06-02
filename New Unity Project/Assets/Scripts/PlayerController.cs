using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject spear;
	private Rigidbody2D playerRigidbody;
	private float nextThrow;
	public float fireRate;
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextThrow) {
			nextThrow = Time.time + fireRate;
			Instantiate (spear, playerRigidbody.transform.position, spear.transform.rotation);
		}

		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		playerRigidbody.velocity = movement*speed;
	}
}
