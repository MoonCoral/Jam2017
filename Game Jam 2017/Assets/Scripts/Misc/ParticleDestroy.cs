using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {
	public float duration = 0.5f;
	void Awake() {
		Destroy (gameObject, duration);
	}
}
