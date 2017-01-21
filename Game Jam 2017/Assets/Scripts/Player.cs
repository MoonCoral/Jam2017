using UnityEngine;
using System.Collections;
using Interfaces;

public class Player : Singleton<Player>, IPlayer {
	public float distanceWalked;

	void Awake() {
		InitiateSingleton ();
	}

	public void moveUp   () { move (Vector2.up   ); }
	public void moveDown () { move (Vector2.down ); }
	public void moveLeft () { move (Vector2.left ); }
	public void moveRight() { move (Vector2.right); }

	public void move (Vector2 movementDirection) {
		Vector2 position       = transform.position;
		Vector2 targetPosition = position + movementDirection;
		StartCoroutine(smoothMove (position, targetPosition, 0.5f));
	}
	IEnumerator smoothMove(Vector2 startPos, Vector2 targetPos, float time) {
		float currentTime = 0.0f;
		while (currentTime <= 1.0f) {
			currentTime += Time.deltaTime / time;

			transform.position = Vector2.Lerp (startPos, targetPos, Mathf.SmoothStep(0.0f, 1.0f, currentTime));
			yield return new WaitForEndOfFrame();
		}
	}
	public void shootUp    () { shoot (Vector2.up   ); }
	public void shootDown  () { shoot (Vector2.down ); }
	public void shootLeft  () { shoot (Vector2.left ); }
	public void shootRight () { shoot (Vector2.right); }

	public void shoot(Vector2 movementDirection) {
		
	}

	public void echo () {
		
	}
		
}
