using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarScript : MonoBehaviour {
	public Image image;
	float cooldownTime = 2f;
	public int charges = 5;
	public bool isScaling = false;

	void Start () {
		int currentValue = 0;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space) && !isScaling)
			StartCoroutine (CarlUpdate ());
	}
	IEnumerator CarlUpdate() {
		isScaling = true;
		float targetFill = image.fillAmount + 1f / charges;

		while (image.fillAmount < targetFill) {
			image.fillAmount += ( 1 / cooldownTime / charges) * Time.deltaTime;

			if (image.fillAmount >= targetFill) {
				image.fillAmount = Mathf.Clamp (image.fillAmount, 0, targetFill);
				break;
			}
			yield return new WaitForEndOfFrame ();
		}

		isScaling = false;
	}
}
