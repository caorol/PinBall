using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	private float visiblePosZ = -6.5f;
	private GameObject gameoverText;
	private int score = 0;
	private Text scoreText;
	private const string scorePrefix = "Score: ";

	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find ("GameOverText");
		this.scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		this.scoreText.text = scorePrefix + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "SmallStarTag") {
			score += 5;
		} else if (other.gameObject.tag == "LargeStarTag") {
			score += 30;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			score += 10;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			score += 20;
		}
		scoreText.text = scorePrefix + score.ToString();
	}
}
