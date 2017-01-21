using UnityEngine;
using System.Collections;

namespace Interfaces {
	interface IEnemy {
		void action (); // Action to happen when it's the enemies 
	}
	interface IPlayer {
		void move (Vector2 movementDirection); // Move in a direction
		void shoot(Vector2 movementDirection); // Shoot in a direction
		void echo(); // Echo ability
	}
}