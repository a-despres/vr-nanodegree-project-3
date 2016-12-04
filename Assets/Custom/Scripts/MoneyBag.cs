using UnityEngine;
using System.Collections;

public class MoneyBag : MonoBehaviour {

	public int coinsInWorld;
	public Hud hud;

	public int coinsInBag;

	// Use this for initialization
	void Start () {
		coinsInBag = 0;
	}

	public void PickupCoin () {
		coinsInBag++;
		hud.DisplayMoneyBag ();
	}
}