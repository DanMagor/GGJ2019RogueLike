﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSwitcher: MonoBehaviour {

    public bool LightIsOn() {
        return flashlight.activeSelf;
    }

	void Start () {
		flashlight = transform.Find("Flashlight").gameObject;
		lightnessHighlight = transform.Find("LightnessHighlight").gameObject;
		darknessHighlight = transform.Find("DarknessHighlight").gameObject;
	}
	
	void Update () {
		var angle = getRotationAngle();
		const float RotationSpeed = 90.0f;
		
		if (angle > 5) 
			transform.Rotate(RotationSpeed * Vector3.forward * Time.deltaTime);
		else if (angle < -5) {
			transform.Rotate(-RotationSpeed * Vector3.forward * Time.deltaTime);
		}

		if (Input.GetKeyDown("space")) {
			if(flashlight.activeSelf) {
				flashlight.SetActive(false);
				lightnessHighlight.SetActive(false);
				darknessHighlight.SetActive(true);
			} else if(darknessHighlight.activeSelf) {
				flashlight.SetActive(true);
				lightnessHighlight.SetActive(true);
				darknessHighlight.SetActive(false);
			}
		}
	}

	private float getRotationAngle() {
        var mousePos = Input.mousePosition;
		var point = Camera.main.ScreenToWorldPoint(
			new Vector3(mousePos.x, mousePos.y, 10));
		return Vector3.SignedAngle(transform.right, point - transform.position, Vector3.forward);
	}

	private GameObject flashlight;
	private GameObject lightnessHighlight;
	private GameObject darknessHighlight;
}