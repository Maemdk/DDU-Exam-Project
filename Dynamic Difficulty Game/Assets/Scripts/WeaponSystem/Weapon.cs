using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	string _weaponName;
	public string WeaponName {get; set;}
	float _damage;
	public float Damage {get; set;}
	AudioClip _attackSound;
}
