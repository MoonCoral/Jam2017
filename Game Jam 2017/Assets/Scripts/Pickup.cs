using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	public bool keyCollected = false;
	void Start () {
	
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Key") {
			keyCollected = true;
			Destroy (other.gameObject);
		}
	}
}
