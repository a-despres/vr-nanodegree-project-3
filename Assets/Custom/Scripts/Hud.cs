using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hud : MonoBehaviour {

	public GameObject alert;
	public float alertTime;
	public MoneyBag moneyBag;

	private Transform playerCamera;

	void Awake () {
		playerCamera = gameObject.GetComponent<Transform> ();
	}

	public void DisplayMoneyBag () {
		Text alertText = alert.GetComponentInChildren<Text> ();
		alertText.text = moneyBag.coinsInBag + "/" + moneyBag.coinsInWorld + "\nCoins Collected";

		GameObject coinAlert = Instantiate (alert);
		coinAlert.transform.SetParent (playerCamera, worldPositionStays: false);
		Destroy (coinAlert, alertTime);
	}

	public void DisplayKeyPickup () {
		Text alertText = alert.GetComponentInChildren<Text> ();
		alertText.text = "Key Collected";

		GameObject keyAlert = Instantiate (alert);
		keyAlert.transform.SetParent (playerCamera, worldPositionStays: false);
		Destroy (keyAlert, alertTime);
	}

	public void DisplayLockedDoor () {
		Text alertText = alert.GetComponentInChildren<Text> ();
		alertText.text = "Door Locked";

		GameObject doorAlert = Instantiate (alert);
		doorAlert.transform.SetParent (playerCamera, worldPositionStays: false);
		Destroy (doorAlert, alertTime);
	}
}