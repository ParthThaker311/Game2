using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject spear;
	private Rigidbody2D rb2d;
	private float nextThrow;
	public float fireRate;
	private float direction = 1;
	private float initialX;
	private float currentX;
	private Vector2 movement;
	public float jumpTime;
	private float origJumpTime;
	public float jumpSpeed;
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		initialX = this.transform.position.x;
		currentX = initialX;
		origJumpTime = jumpTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "Player") {
			if (Input.GetButton ("Fire1") && Time.time > nextThrow) {
				nextThrow = Time.time + fireRate;
				Instantiate (spear, rb2d.transform.position, spear.transform.rotation);
			} 
			if (Input.GetButton ("Jump") && jumpTime > 0) {
				nextThrow = Time.time + fireRate;

				movement = new Vector2 (Input.GetAxis ("Horizontal"), jumpSpeed);
				rb2d.velocity =(movement);
				jumpTime--;
			} else {
				movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
				rb2d.velocity = movement * speed;
			}

			Debug.Log (this.transform.position.y);
		} else {
			currentX = this.transform.position.x;
			if (currentX <= initialX - 1) {
				direction = 1;
			} else if (currentX >= initialX + 1) {
				direction = -1;
			}
			rb2d.velocity = new Vector3 (1, 0, 0)*direction;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ground") {
			jumpTime = origJumpTime;
		}
	}
}
