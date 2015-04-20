using UnityEngine;
using System.Collections;

public class DetachParticleSystemOnDestroy : MonoBehaviour {

	void RequestDestroy() {
		ParticleSystem[] systems = gameObject.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem system in systems ) {
			system.gameObject.transform.parent = null;
			system.Stop();
			Destroy(system.gameObject, 10.0f);
		}
	}
}
