using UnityEngine;
using System.Collections;

public class Sunset : MonoBehaviour {

	public GameObject sun;
	public GameObject flashlight;

	Quaternion startRotation;

	private bool isFlashlightOn = false;

	void Awake () {
		startRotation = Quaternion.Euler (45f, 30f, 0f);
	}

	void Start () {
		flashlight.SetActive (false);
		sun.transform.rotation = startRotation;
	}

	// Update is called once per frame
	void Update () {
//		sun.transform.rotation = Quaternion.Slerp (startRotation, endRotation, Time.time / 300f);
		sun.transform.Rotate(0f, 1f * Time.deltaTime, 0f);

		// When the sun moves below the horizon, turn the flashlight on
		if (sun.transform.rotation.eulerAngles.x > 180 && !isFlashlightOn) {
			Debug.Log ("Flashlight turned on.");
			flashlight.SetActive (true);
			isFlashlightOn = true;
		} else if (sun.transform.rotation.eulerAngles.x > 0 && sun.transform.rotation.eulerAngles.x < 180 && isFlashlightOn) {
			Debug.Log ("Flashlight turned off.");
			flashlight.SetActive (false);
			isFlashlightOn = false;
		}
	}
}
