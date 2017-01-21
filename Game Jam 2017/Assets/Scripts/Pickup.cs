using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	public bool keyCollected = false;
	void Start () {
	
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Key") {
			keyCollected = true;
			Destroy(other.gameObject);
		}
	}
}
