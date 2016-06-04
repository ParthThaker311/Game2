using UnityEngine;
public class Throwable: IWeapon
{
	private float damage;
	private string typeOfDamage;
	private GameObject weaponOwner;
	public Throwable (float dmg, string type)
	{
		damage = dmg;
		typeOfDamage = type;
		//weaponOwner = owner;
	}
	public float GetDamage(){
		return damage;
	}
	public string GetTypeOfDamage(){
		return typeOfDamage;
	}

	public void InstantiateObject(){
		//GameObject.Instantiate(
	}
}


