using UnityEngine;
using System.Collections;

public class RotateSprite : MonoBehaviour {

	public float maxSpeed;
	public float minSpeed;
	public int rotateDirection = 0;
	
	private float speed;
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		speed = Random.Range(minSpeed, maxSpeed);
		rb = GetComponent<Rigidbody2D>();
		if( rotateDirection == 0 )
		{
			float dir = Random.value;
			if( dir < .5f )
			{
				rotateDirection = 1;
			}
			else 
			{
				rotateDirection = -1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( rb == null ){
			return;
		}
		rb.rotation = rb.rotation + (speed * Time.deltaTime * rotateDirection);
	}
}
