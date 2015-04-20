using UnityEngine;
using System.Collections;

public class HogBall : OnHogEnemyContact {
	
	public float timeAlive = 30.0f;
	
	private Rigidbody2D rb;
	private Vector2 curVelocity;
	
	void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		curVelocity = rb.velocity;
		timeAlive -= Time.deltaTime;
		
		if( timeAlive < 0 ) {
			Destroy(gameObject);
		}
		
		float newMagnitude = Mathf.Clamp((curVelocity.magnitude * 1.005f), 0.0f, 6.0f);
		rb.velocity = curVelocity.normalized * newMagnitude;
		
		float addDegree = Mathf.Atan2(curVelocity.normalized.y, curVelocity.normalized.x) * (180 / Mathf.PI);
		Debug.Log(addDegree);
		float degree = 90 + addDegree;
		rb.rotation = degree;
		
	}
	
	public override void HandleCollision( Collision2D other ) {
		// Roll over game object
		
		if( other.gameObject.tag == "Enemy" ) {
			rb.velocity = curVelocity;
			Physics2D.IgnoreCollision( other.collider, gameObject.GetComponent<Collider2D>(),true);
		}
		
		other.gameObject.BroadcastMessage("OnHit", gameObject.transform.position, SendMessageOptions.DontRequireReceiver );
	}
}
