using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 100;

    public Animator animator;


    public bool bringingObject = false;
    public PickableItem item = null;

    [SerializeField]
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }

		transform.position += new Vector3(speed * Time.deltaTime,0,0) * Input.GetAxis("Horizontal") +
                              new Vector3(0, speed * Time.deltaTime, 0) * Input.GetAxis("Vertical"); 

        animator.SetFloat("vSpeed", Input.GetAxis("Vertical"));
        animator.SetFloat("hSpeed", Input.GetAxis("Horizontal"));
	}

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision");
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Enemy" || collisionTag == "Exit" || collisionTag == "Trap")
        {
            //SceneManager.LoadScene("SampleScene");
            //SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
            if (bringingObject)
            {
                GameManager.itemsRemaining += 1;
                item.gameObject.SetActive(true);
                bringingObject = false;
                item = null;
            }
            gameManager.respawn();
        }

        if (collision.gameObject.name == "Respawn Point")
        {
            gameManager.arriveRitualRoom();
        }

    }

}
