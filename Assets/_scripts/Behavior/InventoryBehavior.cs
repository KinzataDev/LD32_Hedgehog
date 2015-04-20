using UnityEngine;
using System.Collections;

public class InventoryBehavior : MonoBehaviour {

	public GameObject[] items;
	
	public GameObject currentItem
	{
		get { return items[currentItemIndex]; }
	}
	private int currentItemIndex = 0;
	
	
	public GameObject NextItem() {
		currentItemIndex++;
	
		if( currentItemIndex >= items.Length ) {
			currentItemIndex = 0;
		}
		return currentItem;
	}
	
	public GameObject PreviousItem() {
		currentItemIndex--;
		
		if( currentItemIndex < 0 ) {
			currentItemIndex = items.Length-1;
		}
		return currentItem;
	}
	
	public GameObject SelectRandomItem() {
		return items[ Random.Range(0, items.Length) ];
	}
}
