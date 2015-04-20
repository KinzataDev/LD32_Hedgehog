using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text text;

	private bool allowScoring = true;
	private int score;
	
	public static string HighScoreString = "Hedgegeddon_HighScore";
	
	public void Init() {
		score = 0;
		allowScoring = true;
		text.text = "Score: " + score;
	}
	
	// Use this for initialization
	void Start () {
		Init ();
	}
	
	public void Disable() {
		allowScoring = false;
	}
	
	public int GetScore() {
		return score;
	}
	
	public void UpdateScore(int newScore) {
		if( allowScoring == false ) { return; }
		score += newScore;
		text.text = "Score: " + score;
	}
	
	public static int RetrieveHighScore() {
		return PlayerPrefs.GetInt(HighScoreString);
	}
	
	public static void RecordScore( int score ) {
		if ( score > RetrieveHighScore () ) {
			PlayerPrefs.SetInt(HighScoreString, score);
		}
	}
}
