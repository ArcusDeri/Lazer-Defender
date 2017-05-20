using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void ShipMovementHandler(PlayerShip ship){
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			ship.transform.position += Vector3.left * ship.speed * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			ship.transform.position += Vector3.right * ship.speed * Time.deltaTime;
		}
		float clampedX = Mathf.Clamp (ship.transform.position.x, ship.leftBound + ship.padding, ship.rightBound - ship.padding);
		ship.transform.position = new Vector3 (clampedX,ship.transform.position.y,ship.transform.position.z);
	}
		
}
