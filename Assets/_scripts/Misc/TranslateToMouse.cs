using UnityEngine;
using System.Collections;

public class TranslateToMouse : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		float mousex = Input.mousePosition.x;
		float mousey = Input.mousePosition.y;
		Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3 (mousex,mousey,0));
		gameObject.transform.position = new Vector3( target.x, target.y, 0 );
	}
}
