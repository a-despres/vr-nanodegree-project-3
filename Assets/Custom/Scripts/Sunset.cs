using UnityEngine;
using System.Collections;

public class Sunset : MonoBehaviour {

	public GameObject sun;
	public GameObject flashlight;

	private bool isFlashlightOn = false;

	// Update is called once per frame
	void Update () {
		Quaternion startRotation = Quaternion.Euler (45f, 30f, 0f);
		Quaternion endRotation = startRotation * Quaternion.Euler (0f, 180f, 0f);
		sun.transform.rotation = Quaternion.Slerp (startRotation, endRotation, Time.time / 300f);

		// When the sun reaches the horizon, turn the flashlight on
		if (sun.transform.rotation.x < 0.2 && isFlashlightOn == false) {
			flashlight.SetActive(true);
		}
	}
}
