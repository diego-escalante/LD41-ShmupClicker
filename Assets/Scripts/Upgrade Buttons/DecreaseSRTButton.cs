﻿using UnityEngine;

public class DecreaseSRTButton : UpgradeButton {

	private PlayerShip playerShip;
	private int buysLeft = 29;

	private new void OnEnable() {
		_cost = 50;
		_costIncreaseRate = 1.25f;
		buysLeft = 29;
		playerShip = GameObject.FindWithTag("Player").GetComponent<PlayerShip>();
		base.OnEnable();
	}

	protected override void GainBenefit() {
		playerShip.IncreaseSRT(-2);
		buysLeft--;
		if (buysLeft == 0) {
			costText.text = "MAXED";
			button.interactable = false;
			enabled = false;
		}
	}

}
