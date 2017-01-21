using UnityEngine;
using System.Collections;

namespace Modules
{
	[System.Serializable]
	public class MovementModule : MonoBehaviour {
		public Vector2 startingPosition;
		void Awake() {
			startingPosition = transform.position;
		}
		public void move (Vector2 movementDirection) {
			Vector2 position       = startingPosition;
			Vector2 targetPosition = position + movementDirection;
			StartCoroutine(smoothMove (position, targetPosition, 0.5f));
		}
		public IEnumerator smoothMove(Vector2 startPos, Vector2 targetPos, float time) {
			float currentTime = 0.0f;
			while (currentTime <= 1.0f) {
				currentTime += Time.deltaTime / time;

				transform.position = Vector2.Lerp (startPos, targetPos, Mathf.SmoothStep(0.0f, 1.0f, currentTime));
				yield return new WaitForEndOfFrame();
			}
			startingPosition = targetPos;
		}
	}
}