using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarScript : Singleton<BarScript> {
	public Image image;
	public Image playerTurn;
	public Image enemyturn;	

	float cooldownTime = 0.5f;
	public int charges = 5;
	public int currentCharges = 0;
	public bool isScaling = false;
	public bool isPlayerTurn = true;

	void Awake () {
		InitiateSingleton();
	}

	void Start(){
		playerTurn.fillAmount = 1;
	}
	void Update() {
		//if(Input.GetKeyDown(KeyCode.Space) && !isScaling)
		//	StartCoroutine (CarlUpdate ());
	}
	public void StartScaling() {
		StartCoroutine (CarlUpdate ());
		//if(currentCharges<charges)
		//	currentCharges += 1;
	}
	private IEnumerator CarlUpdate() {
		isScaling = true;
		float targetFill = Mathf.Clamp(image.fillAmount + 1f / charges, 0f, 1f);

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

	public bool useEnergy (){
		//if (currentCharges == 5) {
			image.fillAmount = 0;
			currentCharges = 0;
			return true;
		//}
		//return false;
	}

	public void changeTurn(){
		if (isPlayerTurn) {
			enemyturn.fillAmount = 0;
			playerTurn.fillAmount = 1;
		} else if (!isPlayerTurn) { 
			playerTurn.fillAmount = 0;
			enemyturn.fillAmount = 1;
		}
		isPlayerTurn = !isPlayerTurn;

	}
}
