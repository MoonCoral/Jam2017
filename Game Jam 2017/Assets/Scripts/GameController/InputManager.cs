using UnityEngine;
using System.Collections;
using PropertyAttributes;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager> {
	[ReadOnly] public bool isInteractable = true;

	void Awake() { InitiateSingleton (); }

	void Update() {
		if (isInteractable) {
			bool gotGoodInput = true;
			if      (Input.GetKey (KeyCode.W)) {
				Player.Instance.moveUp   ();
			} 
			else if (Input.GetKey (KeyCode.S)) {
				Player.Instance.moveDown ();
			} 
			else if (Input.GetKey (KeyCode.A)) {
				Player.Instance.moveLeft ();
			} 
			else if (Input.GetKey (KeyCode.D)) {
				Player.Instance.moveRight();
			}
			else if (Input.GetKeyDown (KeyCode.UpArrow   )) {
				Player.Instance.shootUp    ();
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow )) {
				Player.Instance.shootDown  ();
			}
			else if (Input.GetKeyDown (KeyCode.LeftArrow )) {
				Player.Instance.shootLeft  ();
			}
			else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Player.Instance.shootRight ();
			}
			else if (Input.GetAxis ("Echo" ) == 1) {
				Player.Instance.echo  ();
			}
			else if (Input.GetKeyDown(KeyCode.R) && GameObject.Find("Win/Lose").GetComponent<WinLoseControl>().GetOver) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
			else
				gotGoodInput = false;

			if (gotGoodInput) {
				GameController.Instance.StartPlayersTurn ();
			}
		}
	}
}
