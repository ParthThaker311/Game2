using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private float health = 99;
	public GameObject player;
	private float playerDistance;
	private float nextThrow;
	public float fireRate;
	public GameObject spear;
	private Rigidbody2D rb2d;
	private float direction = 1;
	private float initialX;
	private float currentX;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		initialX = this.transform.position.x;
		currentX = initialX;
	}
	
	// Update is called once per frame
	void Update () {
		currentX = this.transform.position.x;
		if (currentX <= initialX - 1) {
			direction = 1;
		} else if (currentX >= initialX + 1) {
			direction = -1;
		}
		rb2d.velocity = new Vector3 (1, 0, 0)*direction;
		playerDistance = Mathf.Sqrt (Mathf.Pow ((player.transform.position.x - this.transform.position.x), 2) + Mathf.Pow ((player.transform.position.y - this.transform.position.y), 2));
		if(playerDistance <= 10 && Time.time > nextThrow){
				nextThrow = Time.time + fireRate;
				Instantiate (spear, this.transform.position, spear.transform.rotation);
		}
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Throw"){
			Destroy (other.gameObject);
			health -= 33;
		}
	}
}
