using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 4f;
	public float spawnDelay = 0.5f;

	private float distance;
	private Vector3 leftMost, rightMost;
	private bool leftDirection = true;
	private bool spawnDone = false;


	// Use this for initialization
	void Start () {
		distance = transform.position.z - Camera.main.transform.position.z;
		leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		SpawnUntilFull ();
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position,new Vector3(width,height));
	}

	// Update is called once per frame
	void Update () {
		if(spawnDone)
			MoveEnemies ();
		if(AllMembersDead()){
			spawnDone = false;
			SpawnUntilFull ();
		}
	}
	private void MoveEnemies(){
		if (leftDirection) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (transform.position.x - width / 2 <= leftMost.x)
			leftDirection = false;
		else if (transform.position.x + width / 2 >= rightMost.x)
			leftDirection = true;
	}
	private bool AllMembersDead(){
		foreach (Transform childPositionGmObj in transform) {
			if(childPositionGmObj.childCount > 0)
				return false;		
		}
		return true;
	}
	private Transform NextFreePosition(){
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount == 0)
				return childPosition;
		}
		spawnDone = true;
		return null;
	}
	private void SpawnUntilFull(){
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		} 
		if (NextFreePosition ())
			Invoke ("SpawnUntilFull", spawnDelay);
	}

}
