using UnityEngine;
using System.Collections;

public class OrderedTrail : MonoBehaviour {
	public int layer;
	void Awake() {
		GetComponent<TrailRenderer> ().sortingOrder = layer;
	}
}
