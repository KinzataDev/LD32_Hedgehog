using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject ammo;
	public float rateOfFire = 0.5f;
	public float bulletSpeed = 5;
	
	public int maxAmmoAdded;
	public int minAmmoAdded;

	public GameObject owner;
	
	public int ammoCount;
	
	public void init() {
		UpdateAmmoCount();
	}
	
	public void Fire( Vector2 target, Vector2 initPos ) {
		if (ammoCount == 0) return;
		
		GameObject bullet = Instantiate( ammo, initPos, Quaternion.identity ) as GameObject;
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		
		Vector2 newVelocity = target.normalized;
		
		rb.velocity = newVelocity * bulletSpeed;
		
		ammoCount--;
		UpdateAmmoCount();
	}
	
	void UpdateAmmoCount() {
		OnAmmoUpdateData dataPackage = new OnAmmoUpdateData(gameObject.name, ammoCount);
		owner.BroadcastMessage("OnAmmoUpdate", dataPackage, SendMessageOptions.DontRequireReceiver);
	}
	
	public void AddAmmo() {
		int ammoToAdd = Random.Range(minAmmoAdded, maxAmmoAdded+1);
		ammoCount += ammoToAdd;
		UpdateAmmoCount();
	}
}
