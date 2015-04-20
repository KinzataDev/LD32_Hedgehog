using UnityEngine;
using System.Collections;

public class OnHogEnemyContact : MonoBehaviour {
	
	public virtual void HandleCollision( Collision2D other ) {
		// Extend me
	}
	
	void OnCollisionEnter2D ( Collision2D other ) {
		// Don't check what the object is, this could lead to interesting behavior (hogs sticking to hogs)
		HandleCollision( other );
	}
}
