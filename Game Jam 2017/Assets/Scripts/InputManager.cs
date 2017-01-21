using UnityEngine;
using System.Collections;
using PropertyAttributes;

public class InputManager : Singleton<InputManager> {
	[ReadOnly] public bool isInteractable = true;

	void Awake() { InitiateSingleton (); }

	void Update() {
		if (isInteractable) {
			bool gotGoodInput = true;
			if      (Input.GetKeyDown (KeyCode.W)) {
				Player.Instance.moveUp   ();
			} 
			else if (Input.GetKeyDown (KeyCode.S)) {
				Player.Instance.moveDown ();
			} 
			else if (Input.GetKeyDown (KeyCode.A)) {
				Player.Instance.moveLeft ();
			} 
			else if (Input.GetKeyDown (KeyCode.D)) {
				Player.Instance.moveRight();
			}
			else if (Input.GetAxis ("Shoot") == 1) {
				Player.Instance.shoot (Vector2.up);
			}
			else if (Input.GetAxis ("Echo" ) == 1) {
				Player.Instance.echo  ();
			}
			else
				gotGoodInput = false;

			if (gotGoodInput) {
				GameController.Instance.StartPlayersTurn ();
			}
		}
	}
}
