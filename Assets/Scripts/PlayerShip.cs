using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {
	public float speed = 15f;
	public float leftBound, rightBound;
	public float padding = 0.8f;
	public GameObject laser;
	public float playerLaserSpeed = 2f;
	private float shootInterval = 0.35f;
	public AudioClip shootSound;
	public AudioClip hitSound;

	private float health = 250f;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		leftBound = leftMost.x;
		rightBound = rightMost.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			PlayerController.ShipMovementHandler (this);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("ShootLaser", 0.00001f, shootInterval);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("ShootLaser");
		}
	}

	public void ShootLaser(){
		AudioSource.PlayClipAtPoint (shootSound, transform.position);
		Vector3	laserPos = this.transform.position;
		laserPos += Vector3.up;
		GameObject firedLaser = Instantiate (laser, laserPos,Quaternion.identity) as GameObject;
		firedLaser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,playerLaserSpeed);
	}
	void OnTriggerEnter2D(Collider2D col){
		EnemyLaser missile = col.gameObject.GetComponent<EnemyLaser> ();
		if (missile) {
			AudioSource.PlayClipAtPoint (hitSound, transform.position);
			health -= missile.getDamage ();
			missile.Hit ();
			if (health <= 0) {
				GameObject.Find ("LevelManager").GetComponent<LevelManager> ().LoadLevel("Win");
				Destroy (gameObject);
			}
		}
	}
}
