using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

	public Text text;
	private string message = "Your best high score was: ";

	// Use this for initialization
	void Start () {
		int score = ScoreController.RetrieveHighScore();
		message = message + score;
		text.text = message;
	}
}
