using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummary : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Text scoreText = GetComponent<Text> ();
		scoreText.text = Score.score.ToString ();
		Score.ResetScore ();
	}
}
