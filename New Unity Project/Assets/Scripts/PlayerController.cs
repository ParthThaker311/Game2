using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	private float maxHealth = 100;
	private float health;
	public float speed;
	public GameObject spear;
	private Rigidbody2D playerRigidbody;
	private float nextThrow;
	public float fireRate;
	private float hpRegen;
	public float regenRate;
	private bool regenDisabled;
	public Image hpBar;
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < maxHealth && Time.time > hpRegen) {
			hpRegen = Time.time + regenRate;
			health++;
		}
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
			hpRegen = Time.time + regenRate * 10;
		}
	}
	void OnGUI(){
		if (health != maxHealth) {
			Vector2 targetPos = Camera.main.WorldToScreenPoint (this.transform.position);
			GUI.Box (new Rect (targetPos.x - 42, targetPos.y - 60, 60, 20), health + "/" + maxHealth);
		}
	}
}
