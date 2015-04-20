using UnityEngine;
using System.Collections;

public class RemoveRigidBodyOnHit : MonoBehaviour {

	void OnHit( Vector3 location ) {
		
		gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
	}
}
