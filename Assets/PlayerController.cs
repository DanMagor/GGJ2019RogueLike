using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 100;

    public Image darkScreen;

    [SerializeField]
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3(speed * Time.deltaTime,0,0) * Input.GetAxis("Horizontal") +
                              new Vector3(0, speed * Time.deltaTime, 0) * Input.GetAxis("Vertical"); 
        if (Input.GetButtonDown("Jump"))
        {
            darkScreen.enabled = !darkScreen.enabled;
            gameManager.LightIsOn = !darkScreen.enabled;
        }
	}
}
