using UnityEngine;
using System.Collections;

public class FlashOnHitBehavior : MonoBehaviour {

	public float flashDelay = 1.0f;
	public float flashTick = 0.1f;
	public int flashCount = 5;

	private SpriteRenderer spriteRenderer;
	private bool flash;
	private bool shouldEnable;
	private float flashTimer = 0.0f;
			
	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		shouldEnable = true;
		flash = false;
		flashTimer = flashTick;
		flashCount = flashCount * 2;
	}
	
	// Update is called once per frame
	void Update () {
		if( flash ) {
			if( flashDelay >= 0.0f ) {
				flashDelay -= Time.deltaTime;
			}
			else {
				TickFlash();
				if( flashCount <= 0 ){
					flash = false;
					Destroy( gameObject );
				}	
			}					
		}
	}
	
	void TickFlash() {
	
		flashTimer -= Time.deltaTime;
		if( flashTimer <= 0.0f ) {
			shouldEnable = !shouldEnable;
			spriteRenderer.enabled = shouldEnable;
			flashTimer = flashTick;
			flashCount -= 1;
		}
	}
	
	void OnHit(Vector3 location) {
		flash = true;
	}
}
