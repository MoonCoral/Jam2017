using UnityEngine;
using System.Collections;
using Interfaces;

[RequireComponent(typeof(MovementModule))]
[RequireComponent(typeof(ShootingModule))]
public class Player : Singleton<Player>, IMovable, IAttacking {
	public GameObject keyUI;

	private MovementModule movementModule; 
	private ShootingModule shootingModule;

	public MovementModule MovementModule { get { return movementModule; } }
	public ShootingModule ShootingModule { get { return shootingModule; } }

	void Awake() { 
		InitiateSingleton ();
		movementModule = GetComponent<MovementModule> ();
		shootingModule = GetComponent<ShootingModule> ();
	}

	public void moveUp   () { movementModule.move (Vector2.up   );  BarScript.Instance.StartScaling ();}
	public void moveDown () { movementModule.move (Vector2.down );  BarScript.Instance.StartScaling ();}
	public void moveLeft () { movementModule.move (Vector2.left );  BarScript.Instance.StartScaling ();}
	public void moveRight() { movementModule.move (Vector2.right);  BarScript.Instance.StartScaling ();}

	public void shootUp    () {
		if (BarScript.Instance.useEnergy ())
			shootingModule.shoot (ShootingModule.ShootingAngles.Up   ); 
		}
	public void shootDown  () { 
		if (BarScript.Instance.useEnergy ())
			shootingModule.shoot (ShootingModule.ShootingAngles.Down ); 
		}
	public void shootLeft  () { 
		if (BarScript.Instance.useEnergy ())
			shootingModule.shoot (ShootingModule.ShootingAngles.Left ); 
		}
	public void shootRight () { 
		if (BarScript.Instance.useEnergy ())
			shootingModule.shoot (ShootingModule.ShootingAngles.Right); 
		}

	public void echo () {


	    if (BarScript.Instance.useEnergy())
	    {
	        GetComponent<AudioSource>().Play();
	    }
	}

	void OnTriggerEnter2D(Collider2D other) {
		if      (other.tag == "Wall") {
			movementModule.StopAllCoroutines ();
			movementModule.StartSmoothMove(transform.position, movementModule.startingPosition, 0.20f);
		}
		else if (other.tag == "Key" ) {
			keyUI.SetActive (true);
			Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
		}
	}
}