using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableImageOnSelect : MonoBehaviour {

	public string selectName;
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		if( selectName == null || selectName == "") {
			selectName = gameObject.name;
		}
	}
	
	void OnSelect( string name ) {
		if( name == selectName ) {
			image.enabled = true;
		}
		else if (image.enabled == true ) {
			image.enabled = false;
		}
	}
	
	
}
