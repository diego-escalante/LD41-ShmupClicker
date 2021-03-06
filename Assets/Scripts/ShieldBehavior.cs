﻿using System.Collections;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour {

	public bool Shielded {get {return shielded;} set {shielded = value;}}
	private bool shielded = true;
	private float srt = 60f;

	private Renderer rend;
	private SoundController soundController;

	public void Start() {
		rend = transform.GetChild(0).GetComponent<Renderer>();
		soundController = GameObject.FindWithTag("GameController").GetComponent<SoundController>();
	}

	public void OnEnable() {
		CancelInvoke();
		shielded = true;
	}

	public void OnDisable() {
		StopCoroutine("RegenerateShield");
	}

	public bool CanAbsorbDamage() {
		if (shielded) {
			shielded = false;
			rend.enabled = false;
			StartCoroutine("RegenerateShield");
			return true;
		}
		return false;
	}

	public void setSrt(float srt) {
		this.srt = srt;
	}

	private IEnumerator RegenerateShield() {
		for (float elapsedTime = 0; elapsedTime <= srt; elapsedTime += Time.deltaTime) {
			yield return null;
		}
		shielded = true;
		rend.enabled = true;
		soundController.playShieldRecharge();
	} 
}
