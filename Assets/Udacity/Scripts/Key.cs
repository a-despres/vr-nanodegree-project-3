using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	public GameObject keyPoof;
	public Door door;
	public Hud hud;
	public bool isCollected = false;

	void Update()
	{
		//Bonus: Key Animation
		transform.Rotate (0, 50.0f * Time.deltaTime, 0);
	}

	public void OnKeyClicked()
	{
		// Collect Key
		isCollected = true;

		// Show Key Pickup Alert
		hud.DisplayKeyPickup ();

        // Instatiate the KeyPoof Prefab where this key is located
		// Make sure the poof animates vertically
		Vector3 positionOfKey = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.transform.position.z);
		Instantiate(keyPoof, positionOfKey, Quaternion.Euler(-90, 0, 0));

        // Call the Unlock() method on the Door
		door.Unlock ();

		// Destroy the key. Check the Unity documentation on how to use Destroy
		Destroy (gameObject);
    }
}