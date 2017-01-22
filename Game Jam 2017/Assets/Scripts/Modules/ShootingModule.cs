using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShootingModule : MonoBehaviour {
	public class ShootingAngles {
		public class ValuePair {
			public ValuePair (string name, float value) {
				this.name  = name ;
				this.value = value;
			}
			public string name ;
			public float  value;
		}
		public static readonly ValuePair Up    = new ValuePair("Up"   , 0f  );
		public static readonly ValuePair Left = new ValuePair("Left" , 90f );
		public static readonly ValuePair Down  = new ValuePair("Down" , 180f);
		public static readonly ValuePair Right  = new ValuePair("Right", 270f);
	}
	public GameObject projectile;

	public void shoot( ShootingAngles.ValuePair angle ) {
		Quaternion rot = Quaternion.Euler (0, 0, angle.value);
		GameObject projObj = Instantiate (projectile, transform.position, rot) as GameObject;
        GetComponent<AudioSource>().Play();
    }
}