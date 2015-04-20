using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject objectToSpawn;
	public float spawnRateMax = 3.0f;
	public float spawnRateMin = 3.0f;
	
	public bool destroyOnDisable = true;
	public bool shouldSpawn = true;
	
	public float xRange = 5.0f;
	public float yRange = 5.0f;
	
	private float timeToSpawn;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	public void Init() {
		timeToSpawn = spawnRateMin;
		shouldSpawn = true;
	}
	
	public void Disable() {
		if( destroyOnDisable == true ) {
			Destroy(gameObject);
		}
		
		shouldSpawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if( shouldSpawn ) {
			timeToSpawn -= Time.deltaTime;
			if( timeToSpawn <= 0.0f ) {
				
				Spawn ();
				timeToSpawn = Random.Range(spawnRateMin,spawnRateMax);
			}
		}
	}
	
	public virtual GameObject Spawn() {
		float xSpawn = Random.Range( -xRange, xRange );
		float ySpawn = Random.Range( -yRange, yRange );
			
		Vector3 curPos = gameObject.transform.position;
		Vector2 location = new Vector2(curPos.x + xSpawn, curPos.y + ySpawn);
		
		GameObject newObj = Instantiate( objectToSpawn, new Vector3(location.x, location.y, 0), Quaternion.identity) as GameObject;
		return newObj;
	}
	
	public virtual GameObject Spawn(Vector2 location) {
		GameObject newObj = Instantiate( objectToSpawn, new Vector3(location.x, location.y, 0), Quaternion.identity) as GameObject;
		return newObj;
	}
	
	void OnDrawGizmos() {
	
		Gizmos.DrawWireCube( gameObject.transform.position, new Vector3(xRange*2, yRange*2, 0))	;
	}
}
