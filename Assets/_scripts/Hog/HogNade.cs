using UnityEngine;
using System.Collections;

public class HogNade : MonoBehaviour {

	public float airTime = 1.0f;
	public float shellForce = 10;
	public int numShells = 10;
	public GameObject shell;
	
	// Update is called once per frame
	void Update () {
		airTime -= Time.deltaTime;
		
		if( airTime < 0 ) {
			Explode();
		}
	}
	
	void Explode() {
		for( int i = 0; i < numShells; i++ ) {
			float degree = Random.value * 360;
			Vector2 direction = Quaternion.Euler(0,0,degree) * Vector2.up;
			
			GameObject obj = Instantiate( shell, gameObject.transform.position, Quaternion.identity) as GameObject;
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			rb.velocity = direction * shellForce;
		}
	
		Destroy( gameObject );
	}
}
