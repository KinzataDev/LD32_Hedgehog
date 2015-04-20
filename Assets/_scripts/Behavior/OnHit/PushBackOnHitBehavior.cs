using UnityEngine;
using System.Collections;

public class PushBackOnHitBehavior : MonoBehaviour {

	public float force = 2;
	public float timeApplied = 0.5f;
	
	private bool move = true;
	private bool hit = false;
	
	// Update is called once per frame
	void Update () {
		if( hit && move == true ){
			timeApplied -= Time.deltaTime;
			if( timeApplied <= 0.0f) {
				move = false;
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
		}
	}
	
	void OnHit( Vector3 location ) {
		hit = true;
		Vector3 movementVector = (gameObject.transform.position - location).normalized;
		
		movementVector.z = 0;
		gameObject.GetComponent<Rigidbody2D>().velocity = movementVector * force;
	}
}
