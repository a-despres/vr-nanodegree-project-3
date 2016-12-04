using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	// HUD
	public Hud hud;

	// Audio clips
	public AudioClip lockedAudioClip;
	public AudioClip unlockedAudioClip;

	// Boolean used to determined if the door is in focus; checked in Update()
	private bool isFocused = false;

	// Door colors
	private Renderer renderer;
	private Color colorOriginal = Color.gray;	// out of focus
	private Color colorLocked = Color.red;	// in focus, locked
	private Color colorUnlocked = Color.green; // in focus, unlocked

    // Create a boolean value called "locked" that can be checked in Update() 
	bool isLocked = true;

	// "doorFullyRaised" is set to true by default so that the door does not open automatically when the key is collected
	bool isFullyRaised = true;

	void Awake () {
		renderer = gameObject.GetComponent<Renderer> ();
		renderer.material.color = colorOriginal;
	}

    void Update () {

		// If the reticle is focused on the door
		if (isFocused) {
			Focus ();
		} else {
			LoseFocus ();
		}
			
		// If the door is unlocked and it is not fully raised
		if (!isLocked && !isFullyRaised) {
			// Animate the door raising up
			if (gameObject.transform.position.y <= 24) {
				gameObject.transform.Translate (0, 10f * Time.deltaTime, 0);
			}
		}
    }

	public void OnDoorClicked () {
		AudioSource doorAudio = gameObject.GetComponent<AudioSource> ();

		// Play audio clip; determined by the collection of the key in the scene
		if (!isLocked) { 
			isFullyRaised = false;	
			doorAudio.clip = unlockedAudioClip;
			doorAudio.Play ();
		} else {
			doorAudio.clip = lockedAudioClip;
			doorAudio.Play ();

			// Show Locked Door Alert
			hud.DisplayLockedDoor ();
		}
	}

    public void Unlock ()
    {
        // You'll need to set "locked" to false here
		isLocked = false;
    }

	public void PointerEnter () {
		// Reticle is focused on the door
		isFocused = true;
	}

	public void PointerExit () {
		// Reticle is no longer focused on the door
		isFocused = false;
	}

	void Focus () {
		// Change color of door when in focus
		if (isLocked) {
			renderer.material.color = Color.Lerp (colorOriginal, colorLocked, Time.time * 1.0f);
		} else {
			renderer.material.color = Color.Lerp (colorOriginal, colorUnlocked, Time.time * 1.0f);
		}
	}

	void LoseFocus () {
		// Change color of door back to original color when not in focus
		if (isLocked) {
			renderer.material.color = Color.Lerp (colorLocked, colorOriginal, Time.time * 1.0f);
		} else {
			renderer.material.color = Color.Lerp (colorUnlocked, colorOriginal, Time.time * 1.0f);
		}
	}
}