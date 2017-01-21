using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	private static T instance;

	public void InitiateSingleton() {
		if (instance != null && instance != this)
			Destroy (this.gameObject);
		else
			instance = this as T;
	}

	public static T Instance { get { return instance; } }
}
