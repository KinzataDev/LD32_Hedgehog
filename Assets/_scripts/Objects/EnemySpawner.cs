using UnityEngine;
using System.Collections;

public class EnemySpawner : Spawner {

	public GameObject target;
	public string targetTag;
	
	public override GameObject Spawn() {
		GameObject newObj = base.Spawn ();
		
		return AssignTarget(newObj);
	}
	
	public override GameObject Spawn (Vector2 location)
	{
		GameObject newObj = base.Spawn (location);
		
		return AssignTarget(newObj);
	}
	
	GameObject AssignTarget ( GameObject newObj ) {
		if( target == null ) {
			target = GameObject.FindGameObjectWithTag(targetTag);
		}
		
		newObj.GetComponent<RaycastMoveToTarget>().target = target;
		
		return newObj;
	}
}
