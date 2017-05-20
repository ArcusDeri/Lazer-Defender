using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour {
	private float damage = 100f;

	public void Hit(){
		Destroy (gameObject);
	}

	public float getDamage(){
		return damage;
	}
}
