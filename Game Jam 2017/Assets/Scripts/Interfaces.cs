using UnityEngine;
using System.Collections;
using Modules;

namespace Interfaces {
	interface IEnemy {
		void action (); // Action to happen when it's the enemies 
	}
	interface IPlayer {
		void shoot(Vector2 movementDirection); // Shoot in a direction
		void echo(); // Echo ability
	}
	interface IMovable {
		MovementModule MovementModule { get; }
	}
}