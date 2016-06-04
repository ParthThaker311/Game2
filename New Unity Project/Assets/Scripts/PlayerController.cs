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
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		initialX = this.transform.position.x;
		currentX = initialX;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextThrow) {
			nextThrow = Time.time + fireRate;
			Instantiate (spear, rb2d.transform.position, spear.transform.rotation);
		} 
		if (this.tag == "Player") {
			Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			rb2d.velocity = movement * speed;
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
}
