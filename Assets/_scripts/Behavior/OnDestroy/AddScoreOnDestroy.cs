using UnityEngine;
using System.Collections;

public class AddScoreOnDestroy : MonoBehaviour {

	public int value;

	private ScoreController scoreController;
	
	// Use this for initialization
	void Start () {
		scoreController = FindObjectOfType( typeof(ScoreController) ) as ScoreController;
	}
	
	void OnDestroy() {
		scoreController.UpdateScore(value);
	}
}
