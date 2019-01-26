using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour: MonoBehaviour {

	public float speed = 5.0f;
	public int hitPoints = 10;

	
	// Use this for initialization
	void Start () {
		flashlight = transform.Find("Flashlight").gameObject;
		lightnessHighlight = transform.Find("LightnessHighlight").gameObject;
		darknessHighlight = transform.Find("DarknessHighlight").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		var angle = getRotationAngle();
		const float RotationSpeed = 90.0f;
		
		if (angle > 5) 
			transform.Rotate(RotationSpeed * Vector3.forward * Time.deltaTime);
		else if (angle < -5) {
			transform.Rotate(-RotationSpeed * Vector3.forward * Time.deltaTime);
		}
		float vMovement = Input.GetAxis("Vertical");
		float hMovement = Input.GetAxis("Horizontal");

		transform.Translate((Vector3.up * vMovement + Vector3.right * hMovement)
		 * speed * Time.deltaTime, Space.World);

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

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Missile") {
		  	hitPoints -= 1;
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
