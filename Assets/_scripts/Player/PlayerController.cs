using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 1f;
	
	private Rigidbody2D rb;
	private float inX;
	private float inY;
	

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	 	inX = Input.GetAxis("Horizontal");
		inY = Input.GetAxis("Vertical");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector2 newVelocity = new Vector2( inX, inY ).normalized * speed;
		rb.velocity = newVelocity;
	}
}
