using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Interfaces;

public class GameController : Singleton<GameController> {
	public float playerIntermissionDuration = 0.5f;
	public float enemyIntermissionDuration  = 0.5f;

	private List<IEnemy> enemyList;

	void Awake() {
		InitiateSingleton ();
	}

	void Start() {
		// Set up level
		// Initiate Enemy List
		enemyList = new List<IEnemy>();
	}

	public void StartPlayersTurn() {
		StartCoroutine (playersTurn ());
	}
	private IEnumerator playersTurn() {
		InputManager.Instance.isInteractable = false;
		yield return new WaitForSeconds (playerIntermissionDuration);
		//StartCoroutine (enemiesTurn ());
		InputManager.Instance.isInteractable = true;
	}
	private IEnumerator enemiesTurn() {
		yield return new WaitForSeconds (enemyIntermissionDuration );
		foreach (IEnemy enemy in enemyList) {
			enemy.action ();
		}
		InputManager.Instance.isInteractable = true;
	}
}
