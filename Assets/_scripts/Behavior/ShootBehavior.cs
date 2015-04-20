using UnityEngine;
using System.Collections;

/*
	Top level shooting script
*/
public class ShootBehavior : MonoBehaviour {

	public Weapon weapon;
	
	public Vector2 targetVector;
	public GameObject _targetGameObject;
	public bool shouldFire = true;
	
	private float timeToFire;
	private bool canFire = true;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		timeToFire = weapon.rateOfFire;
		canFire = true;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
		// Fire controls
		if ( !canFire ) {
			TickFire();
		}
		else if( canFire && shouldFire )
			Shoot ();
		
	}
	
	void Shoot() {
		if( _targetGameObject != null )
		{
			targetVector = (_targetGameObject.transform.position - gameObject.transform.position ).normalized;
		}
		else {
			targetVector = (new Vector3(targetVector.x, targetVector.y, 0) - gameObject.transform.position).normalized;
		}
		
		if( canFire ) {
		
			weapon.Fire( targetVector, gameObject.transform.position);
			timeToFire = weapon.rateOfFire;
			canFire = false;
		}
	}
	
	void TickFire() {
		timeToFire -= Time.deltaTime;
		if( timeToFire <= 0.0f ) {
			canFire = true;
		}
	}
	
}
