using UnityEngine;
using System.Collections;

public class WeaponInventory : InventoryBehavior {
	
	public int weaponCount = 4;
	
	private PlayerShootBehavior psb;
	
	void Start () {
		psb = GetComponent<PlayerShootBehavior>();
		
		items = new GameObject[weaponCount];
		for( int i=0; i < weaponCount; i++ ) {
			GameObject item = Instantiate(Resources.Load("prefabs/Weapon" + (i+1),typeof(GameObject))) as GameObject;
			item.name = "Weapon" + (i+1);
			items[i] = item;
		}
		
		foreach ( GameObject obj in items ) {
			Weapon weapon = obj.GetComponent<Weapon>();
			weapon.owner = gameObject;
			weapon.init();
		}
		psb.weapon = currentItem.GetComponent<Weapon>();
		gameObject.BroadcastMessage("OnSelect", currentItem.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.E) ) {
			Weapon newWeapon = PreviousItem().GetComponent<Weapon>();
			psb.weapon = newWeapon;
			gameObject.BroadcastMessage("OnSelect", newWeapon.gameObject.name);
		}
		else if (Input.GetKeyDown(KeyCode.Q) ) {
			Weapon newWeapon = NextItem().GetComponent<Weapon>();
			psb.weapon = newWeapon;
			gameObject.BroadcastMessage("OnSelect", newWeapon.gameObject.name);
		}
	}
	
	void OnTriggerEnter2D ( Collider2D other ) {
		if( other.gameObject.tag == "Ammo" ) {
			HandleAmmoPickup();
			other.gameObject.SendMessage("RequestDestroy");
			Destroy ( other.gameObject );
		}
	}
	
	// Select a random weapon and have it give itself some ammo
	void HandleAmmoPickup() {
		SelectRandomItem().GetComponent<Weapon>().AddAmmo();
	}
}
