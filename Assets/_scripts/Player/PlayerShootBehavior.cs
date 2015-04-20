using UnityEngine;
using System.Collections;

public class PlayerShootBehavior : ShootBehavior {
	
	// Update is called once per frame
	public override void Update () {
		shouldFire = Input.GetMouseButton(0);
		
		if( shouldFire ){
			float mousex = Input.mousePosition.x;
			float mousey = Input.mousePosition.y;
			Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3 (mousex,mousey,0));
			targetVector = new Vector2( target.x, target.y );
		}
		
		base.Update();
	}
}
