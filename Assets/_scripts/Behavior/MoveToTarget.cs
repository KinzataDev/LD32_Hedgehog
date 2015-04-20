using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour {

	public GameObject target;
	public float speed;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curPos = gameObject.transform.position;
		Vector3 targetPos = target.transform.position;
		
		Vector3 movmentVector = (targetPos - curPos).normalized;
		Vector2 newVelocity = new Vector2(movmentVector.x, movmentVector.y) * speed;
		
		rb.velocity = newVelocity;
	}
	
	void OnHit( Vector3 location ) {
		this.enabled = false;
	}
}
