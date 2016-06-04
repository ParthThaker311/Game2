using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	// Use this for initialization
	private float currentHealth;
	public float maxHealth;
	private float hpRegen;
	public float regenRate;
	public Texture2D hpBarFull;
	public Texture2D hpBarEmpty;
	public float regenDelay;
	public string attackTag;
	void Start(){
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth < maxHealth && Time.time > hpRegen) {
			hpRegen = Time.time + regenRate;
			currentHealth++;
		}
		if (currentHealth <= 0) {
			if (this.tag == "Player") {
				GameObject.FindGameObjectWithTag ("npc").tag = "Player";
			}
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == attackTag){
			Destroy (other.gameObject);
			currentHealth -= 33;
			hpRegen = Time.time + regenRate * regenDelay;
		}
	}

	void OnGUI(){
		if (currentHealth != maxHealth) {
			Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
			//Gets the x position of the mob and centers the hp bar
			float xPosition = screenPos.x - (maxHealth / 2)+14;
			//Gets the mob's y position relative to the screen with an offset that won't screw up on multiple screen sizes
			float yPosition = Camera.main.pixelHeight - screenPos.y - (Camera.main.pixelHeight / 8);
			//Scales the bar's height based on the size of the enemy
			GUI.DrawTexture(new Rect(xPosition,yPosition,maxHealth*.75f,15), hpBarEmpty);
			GUI.DrawTexture(new Rect(xPosition,yPosition,currentHealth*.75f,15), hpBarFull);
			//GUI.Box (new Rect (targetPos.x+drawX, targetPos.y+drawY, maxHealth*.75f, 20), health + "/" + maxHealth);
		}
	}
}
