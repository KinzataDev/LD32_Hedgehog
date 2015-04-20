using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModifyTextOnAmmoUpdate : MonoBehaviour {

	private string selectName;
	private Text text;

	// Use this for initialization
	void Start () {
		selectName = gameObject.name;
		text = GetComponent<Text>();
	}
	
	void OnAmmoUpdate(OnAmmoUpdateData data) {
		if( data.name == selectName ) {
			text.text = data.ammoCount.ToString();
		}
	}
	
}
