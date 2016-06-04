using System;
using UnityEngine;

public interface IWeapon
{
	float GetDamage();

	string GetTypeOfDamage();

	void InstantiateObject ();

}


