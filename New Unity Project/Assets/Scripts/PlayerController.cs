using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private float health = 99;
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
		Debug.Log (this.transform.position.x);
		if (health <= 0) {
			Destroy (gameObject);
		}
		if (Input.GetButton ("Fire1") && Time.time > nextThrow) {
			nextThrow = Time.time + fireRate;
			Instantiate (spear, playerRigidbody.transform.position, spear.transform.rotation);
		}

		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		playerRigidbody.velocity = movement*speed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "EnemyThrow"){
			Destroy (other.gameObject);
			health -= 33;
		}
	}
}
