using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Enemy" || collisionTag == "Exit" || collisionTag == "Trap")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Enemy" || collisionTag == "Exit" || collisionTag == "Trap")
        {
            SceneManager.LoadScene("Game");
        }

    }

}
