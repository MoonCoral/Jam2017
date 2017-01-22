using UnityEngine;
using System.Collections;

namespace Modules
{
	[System.Serializable]
	public class MovementModule : MonoBehaviour {
		public Vector2 startingPosition;
		void Start() {
			startingPosition = transform.position;
		}
		public void move (Vector2 movementDirection) {
			Vector2 position       = startingPosition;
			Vector2 targetPosition = position + movementDirection;
			StartSmoothMove (position, targetPosition, 0.5f);
		}
		public void StartSmoothMove(Vector2 startPos, Vector2 targetPos, float time) {
			StartCoroutine (smoothMove (startPos, targetPos, time));
		}
		private IEnumerator smoothMove(Vector2 startPos, Vector2 targetPos, float time) {
			float currentTime = 0.0f;
			while (currentTime <= 1.0f) {
				currentTime += Time.deltaTime / time;
				transform.position = Vector2.Lerp (startPos, targetPos, Mathf.SmoothStep(0.0f, 1.0f, currentTime));
				yield return new WaitForEndOfFrame();
			}
			startingPosition = targetPos;
		}
	}

	[System.Serializable]
	public class ShootingModule : MonoBehaviour {
		public GameObject projectile;

		public void shoot(float angle) {
			Quaternion rot = Quaternion.Euler (0, 0, angle);
			GameObject projObj = Instantiate (projectile, transform.position, rot) as GameObject;
		}
	}
}