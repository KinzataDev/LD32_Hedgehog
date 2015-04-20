using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModifyTextAlphaOnSelect : MonoBehaviour {

	private string selectName;
	private Text text;
	
	public float maxAlpha = 150;
	public float minAlpha = 50;

	// Use this for initialization
	void Start () {
		selectName = gameObject.name;
		text = GetComponent<Text>();
		maxAlpha = maxAlpha/255;
		minAlpha = minAlpha/255;
	}
	
	void OnSelect( string name ) {
		Color color = text.color;
		if( name == selectName ) {
			text.color = new Color(color.r,color.g,color.b,maxAlpha);
		}
		else {
			text.color = new Color(color.r,color.g,color.b,minAlpha);
		}
	}
}
