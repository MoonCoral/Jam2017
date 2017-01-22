using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
	public GameObject explosion;

	public float speed = 1f;
	public float timeToLive = 0.5f;
	void Awake() {
		StartCoroutine (bulletMovement ());
	}
	IEnumerator bulletMovement() {
		float elapsedTime = 0.0f;
		while (elapsedTime < timeToLive) {
			elapsedTime += Time.deltaTime;

			Vector3 pos = transform.position;
			Vector3 velocity = new Vector2 (0, speed);
			pos += transform.rotation * velocity * Time.deltaTime;
			transform.position = pos;
			yield return new WaitForEndOfFrame ();
		}
		deathExplosion ();
		Destroy (gameObject);
	}

	void deathExplosion() {
		Instantiate (explosion, transform.position, transform.rotation);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall" || other.tag == "Enemy") {
			StopAllCoroutines ();
			Destroy (gameObject);
			deathExplosion ();
		}
	}
}
