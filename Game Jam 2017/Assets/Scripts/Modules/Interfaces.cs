using UnityEngine;
using System.Collections;

namespace Interfaces {
	interface IEnemy {
		void action (); // Action to happen when it's the enemies 
	}
	interface IMovable {
		MovementModule MovementModule { get; }
	}
	interface IAttacking {
		ShootingModule ShootingModule { get; }
	}
}