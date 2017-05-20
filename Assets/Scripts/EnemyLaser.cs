using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour {
	private float damage = 25f;

	public void Hit(){
		Destroy (gameObject);
	}

	public float getDamage(){
		return damage;
	}
}
