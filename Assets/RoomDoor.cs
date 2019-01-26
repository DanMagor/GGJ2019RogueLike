using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomDoor : MonoBehaviour {

    public Room currentRoom;
    public Room nextRoom;
    //public UnityStandardAssets.Cameras.AutoCam autoCamScript;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with Door");
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Player")
        {
            //Debug.Log(autoCamScript.name);
            //autoCamScript.SetTarget(nextRoom);
            GameManager.resetRoom(currentRoom);
            GameManager.changeRooms(nextRoom);
            Debug.Log("Door collision with Player");
            //SceneManager.LoadScene("SampleScene");
        }

    }
}
