using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {
	private float health = 200f;
	private float shotsPerSecond = 0.5f;
	private Score ScoreController;

	public GameObject laser;
	public float enemyLaserSpeed = -6f;
	public int scoreValue = 150;
	public AudioClip shootSound;
	public AudioClip destroyedSound;

	void Start(){
		ScoreController = GameObject.Find ("ScoreText").GetComponent<Score>();
	}
	void OnTriggerEnter2D(Collider2D col){
		PlayerLaser missile = col.gameObject.GetComponent<PlayerLaser> ();
		if (missile) {
			health -= missile.getDamage ();
			missile.Hit ();
			if (health <= 0f) {
				AudioSource.PlayClipAtPoint (destroyedSound, transform.position);
				Destroy (gameObject);
				ScoreController.ScorePoints (scoreValue);
			}
		}
	}

	void Update(){
		float chanceToShoot = Time.deltaTime * shotsPerSecond;
		//Debug.Log (chanceToShoot);
		if (Random.value < chanceToShoot)
			EnemyShoot ();
	}
	public void EnemyShoot(){
		AudioSource.PlayClipAtPoint (shootSound, transform.position);
		Vector3	laserPos = this.transform.position;
		laserPos += Vector3.down;
		GameObject firedLaser = Instantiate (laser, laserPos,Quaternion.identity) as GameObject;
		firedLaser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,enemyLaserSpeed);
	}
}
