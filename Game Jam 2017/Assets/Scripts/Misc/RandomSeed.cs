using UnityEngine;
using System.Collections;

public class RandomSeed : MonoBehaviour {
	void Awake() {
		GetComponent<ParticleSystem> ().randomSeed = (uint)Random.Range (0, 1000);
	}
	void Start() {
		GetComponent<ParticleSystem> ().Play ();
	}
}
