using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	public GameObject coinPoof;
	public MoneyBag moneyBag;

    public void OnCoinClicked () {
		// Instantiate the CoinPoof Prefab where this coin is located
		// Make sure the poof animates vertically
		Vector3 positionOfCoin = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.transform.position.z);
		Instantiate(coinPoof, positionOfCoin, Quaternion.Euler(-90, 0, 0));

		// Add Coin to Money Bag
		moneyBag.PickupCoin ();

        // Destroy this coin. Check the Unity documentation on how to use Destroy
		Destroy (gameObject);
    }
}