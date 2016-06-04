using UnityEngine;
using System.Collections;

public class SkeletonController : IPlayer {
	private float speed;
	private float nextThrow;
	private float fireRate;
	GameObject skeleton;
	IWeapon bone;
	// Use this for initialization
	void Start () {
		speed = 3;
		fireRate = .5f;
		bone = new Throwable (33, "normal");
		skeleton = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextThrow) {
			nextThrow = Time.time + fireRate;
			bone.InstantiateObject ();
		}

		Vector2 movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		skeleton.GetComponent<Rigidbody2D>().velocity = movement*speed;
	}
	public void Controllable(bool control){
	}

	public IWeapon GetWeapon(){
		return bone;
	}
}
