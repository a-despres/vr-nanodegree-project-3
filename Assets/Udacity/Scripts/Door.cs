using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public AudioClip lockedAudioClip;
	public AudioClip unlockedAudioClip;

    // Create a boolean value called "locked" that can be checked in Update() 
	bool locked = true;

	// "doorFullyRaised" is set to true by default so that the door does not open automatically when the key is collected
	bool doorFullyRaised = true;

    void Update () {
        // If the door is unlocked and it is not fully raised
		if (!locked && !doorFullyRaised) {
			// Animate the door raising up
			gameObject.transform.Translate(0, 10f * Time.deltaTime, 0);
		}
    }

	public void OnDoorClicked () {
		AudioSource doorAudio = gameObject.GetComponent<AudioSource>();

		if (!locked) { 
			doorFullyRaised = false;
			doorAudio.clip = unlockedAudioClip;
			doorAudio.Play ();
		} else {
			Debug.Log ("Door locked");
			doorAudio.clip = lockedAudioClip;
			doorAudio.Play ();
		}
	}

    public void Unlock ()
    {
        // You'll need to set "locked" to false here
		locked = false;
    }
}
