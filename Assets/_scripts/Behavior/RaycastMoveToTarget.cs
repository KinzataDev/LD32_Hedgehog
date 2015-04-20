using UnityEngine;
using System.Collections;

public class RaycastMoveToTarget : MonoBehaviour {
	
	public GameObject target;
	public float speed;
	
	private Rigidbody2D rb;
	private int bushLayerMask = 1 << 11;
	private int degreesPerCheck = 15;
	private int maxChecks = 30; // This is both ways
	
	private Vector2 currentWaypoint;
	private bool waypointNavigation = false;
	public float raycastTime = 1.0f;
	private float raycastTimer = 1.0f;
	
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curPos = gameObject.transform.position;
		Vector3 targetPos;
		
		raycastTimer -= Time.deltaTime;
		if( raycastTimer < 0 ) {
			raycastTimer = raycastTime;
			waypointNavigation = false;
			targetPos = RaycastToTarget();
		}
		else if( waypointNavigation ) {
			targetPos = currentWaypoint;
		}
		else {
			targetPos = target.transform.position;
		}
		
		Vector3 movementVector = (targetPos - curPos).normalized;
		Vector2 newVelocity = new Vector2(movementVector.x, movementVector.y) * speed;
		
		Debug.DrawRay(curPos, movementVector * 2, Color.blue);
		
		float addDegree = Mathf.Atan2(newVelocity.normalized.y, newVelocity.normalized.x) * (180 / Mathf.PI);
		float degree = 90 + addDegree;
		rb.rotation = degree;
		
		rb.velocity = newVelocity;
	}
	
	void OnHit( Vector3 location ) {
		this.enabled = false;
	}
	
	Vector2 RaycastToTarget() {
		Vector3 curPos3 = gameObject.transform.position;
		Vector2 curPos = new Vector2(curPos3.x, curPos3.y);
		Vector3 targetPos3 = target.transform.position;
		Vector2 targetPos = new Vector2(targetPos3.x, targetPos3.y);
		
		Vector2 direction = ( targetPos - curPos ).normalized;
		float distance = ( targetPos - curPos).magnitude;
		
		RaycastHit2D hit = Physics2D.Raycast( curPos, direction, distance, bushLayerMask);
		
		if( hit ) {
			Debug.DrawRay(curPos, direction *  hit.distance, Color.red);
			
			Vector2 waypoint = FindEdge( curPos, targetPos, direction, hit.point );
			currentWaypoint = waypoint;
			waypointNavigation = true;
			
			return waypoint;
		}
		else {
			Debug.DrawRay(curPos, direction * distance, Color.black);
			
			waypointNavigation = false;
			return targetPos;
		}
	}
	
	Vector2 FindEdge( Vector2 curPos, Vector2 targetPos, Vector2 direction, Vector2 point ) {
		
		Vector2 leftDirection = FindLeftEdge(degreesPerCheck, direction, curPos);
		Vector2 rightDirection = FindLeftEdge(-degreesPerCheck, direction, curPos);
		
		Vector2 leftWaypoint = (leftDirection * 2) + curPos;
		Vector2 rightWaypoint = (rightDirection * 2) + curPos;
		
		Debug.DrawLine(curPos, leftWaypoint, Color.black);
		Debug.DrawLine(curPos, rightWaypoint, Color.black);
		
		// Pick the shortest distance to the original target
		// Cast from the left and right waypoints, check the distance
		Vector2 leftTargetDirection = (targetPos - leftWaypoint).normalized;
		Vector2 rightTargetDirection = (targetPos - rightWaypoint).normalized;
		
		float leftDistance = Physics2D.Raycast( leftWaypoint, leftTargetDirection, 1000, ~bushLayerMask).distance;
		float rightDistance = Physics2D.Raycast( rightWaypoint, rightTargetDirection, 1000, ~bushLayerMask).distance;
		
		Debug.Log("Left: " + leftDistance);
		Debug.Log("Right: " + rightDistance);
		
		if( leftDistance > rightDistance ) {
			return rightWaypoint;
		}
		else {
			return leftWaypoint;
		}
	}
	
	Vector2 FindLeftEdge(int degree, Vector2 direction, Vector2 curPos ) {
		RaycastHit2D hit;
		Vector3 testVector;
		
		testVector = Quaternion.Euler(0,0,degree) * direction;
		direction = new Vector2(testVector.x, testVector.y);
		hit = Physics2D.Raycast( curPos, direction, 100, bushLayerMask);
		
		if(hit) {
			Debug.DrawRay(curPos, direction * hit.distance, Color.red);
		}
		
		int i = 1;
		// Rotate the direction by degrees, and check again
		while( hit ) {
			testVector = Quaternion.Euler(0,0,degree) * direction;
			direction = new Vector2(testVector.x, testVector.y);
			
			hit = Physics2D.Raycast( curPos, direction, 5, bushLayerMask);
			
			if( hit ) {
				Debug.DrawRay(curPos, direction * hit.distance, Color.red);		
			}
			else {
				return direction;
			}
			
			if( i++ > maxChecks ) {
			
				break;
			}
		}	
		
		return direction;
	}
}