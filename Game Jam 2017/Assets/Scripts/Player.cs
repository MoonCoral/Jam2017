﻿using UnityEngine;
using System.Collections;
using Interfaces;
using Modules;

public class Player : Singleton<Player>, IPlayer, IMovable {
	private MovementModule movementModule; 

	public MovementModule MovementModule { get { return movementModule; } }

	void Awake() { 
		InitiateSingleton ();
		movementModule = gameObject.AddComponent<MovementModule> ();
	}

	public void moveUp   () { movementModule.move (Vector2.up   ); }
	public void moveDown () { movementModule.move (Vector2.down ); }
	public void moveLeft () { movementModule.move (Vector2.left ); }
	public void moveRight() { movementModule.move (Vector2.right); }

	void OnTriggerEnter2D(Collider2D other) {
		movementModule.StopAllCoroutines ();
		StartCoroutine (movementModule.smoothMove (transform.position, movementModule.startingPosition, 0.20f));
	}

	public void shootUp    () { shoot (Vector2.up   ); }
	public void shootDown  () { shoot (Vector2.down ); }
	public void shootLeft  () { shoot (Vector2.left ); }
	public void shootRight () { shoot (Vector2.right); }

	public void shoot(Vector2 movementDirection) {
		
	}

	public void echo () {

	}
<<<<<<< d10b54dd3a422c9090212be34e96a42b51b1684d
		
}
=======
}
>>>>>>> sss
