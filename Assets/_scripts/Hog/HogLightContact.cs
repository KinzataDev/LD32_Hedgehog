using UnityEngine;
using System.Collections;

public class HogLightContact : OnHogEnemyContact {
	
	public float avoidPlayerWeaponTime = 0.1f;
	private bool collideWithPlayerWeapon = false;
	
	public float timeAlive = 10f;
	
	void Update() {
		timeAlive -= Time.deltaTime;
		
		if( timeAlive < 0 ) {
			Destroy(gameObject);
		}
	
		if( collideWithPlayerWeapon == false ) {
			avoidPlayerWeaponTime -= Time.deltaTime;
			if( avoidPlayerWeaponTime < 0 ) {
				collideWithPlayerWeapon = true;
			}
		}
	}
	
	public override void HandleCollision( Collision2D other ) {
		// Stick to the gameobject
		if( other.gameObject.tag == "PlayerWeapon" && collideWithPlayerWeapon == false ) {
			return;
		}
		
		gameObject.transform.parent = other.gameObject.transform;
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
		if( rb != null ) 
			Destroy(rb);
			
		other.gameObject.BroadcastMessage("OnHit", gameObject.transform.position, SendMessageOptions.DontRequireReceiver );
	}
}
