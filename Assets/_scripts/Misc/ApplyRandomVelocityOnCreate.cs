using UnityEngine;
using System.Collections;

public class ApplyRandomVelocityOnCreate : MonoBehaviour {

	public float value;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2( Random.Range(-value, value),Random.Range(-value,value))	;
	}
}
