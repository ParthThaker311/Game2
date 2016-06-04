using System;
using UnityEngine;

public interface IPlayer
{
	void Controllable (bool toggle);

	IWeapon GetWeapon();
}


