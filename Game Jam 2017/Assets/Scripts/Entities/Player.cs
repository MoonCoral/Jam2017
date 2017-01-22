﻿using UnityEngine;
using System.Collections;
using Interfaces;
using Modules;


public class Player : Singleton<Player>, IPlayer, IMovable{
	public GameObject keyUI;

	private MovementModule movementModule; 
	private ShootingModule shootingModule;

	public MovementModule MovementModule { get { return movementModule; } }
	public ShootingModule ShootingModule { get { return shootingModule; } }

	void Awake() { 
		InitiateSingleton ();
		movementModule = gameObject.AddComponent<MovementModule> ();
		shootingModule = gameObject.AddComponent<ShootingModule> ();
	}

	public void moveUp   () { movementModule.move (Vector2.up   ); }
	public void moveDown () { movementModule.move (Vector2.down ); }
	public void moveLeft () { movementModule.move (Vector2.left ); }
	public void moveRight() { movementModule.move (Vector2.right); }

	public void shootUp    () { shoot (Vector2.up   ); }
	public void shootDown  () { shoot (Vector2.down ); }
	public void shootLeft  () { shoot (Vector2.left ); }
	public void shootRight () { shoot (Vector2.right); }

	public void shoot(Vector2 movementDirection) {

		if (BarScript.Instance.useEnergy ())
			Debug.Log ("you done a shoot");
		else
			Debug.Log("you didnt done a shoot");

	}

	public void echo () {


		if (BarScript.Instance.useEnergy ())
			Debug.Log ("you done a echo");
		else
			Debug.Log("you didnt done a echo");
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			movementModule.StopAllCoroutines ();
			movementModule.StartSmoothMove(transform.position, movementModule.startingPosition, 0.20f);
		}
		else if (other.tag == "Key") {
			keyUI.SetActive (true);
			Destroy(other.gameObject);
		}
	}
}