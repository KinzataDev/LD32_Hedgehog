using UnityEngine;
using System.Collections;

public class PlayerHitController : MonoBehaviour {

	public int hitpoints = 1;
	
	private GameController gc;
	
	void Start() {
		gc = FindObjectOfType( typeof( GameController) ) as GameController;
	}
	
	void OnCollisionEnter2D ( Collision2D other ) {
		if( other.gameObject.tag == "Enemy" ) {
			HandleHit();
		}
	}
	
	void HandleHit() {
		hitpoints--;
		
		if( hitpoints == 0 ) {
			KillPlayer();
		}
	}
	
	void KillPlayer() {
		GameObject camera = GetComponentInChildren<Camera>().gameObject;
		camera.transform.parent = null;
		gc.GameOver();
	}
}
