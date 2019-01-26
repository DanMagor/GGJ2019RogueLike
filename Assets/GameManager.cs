using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool LightIsOn = true;
    public static UnityStandardAssets.Cameras.AutoCam autoCamScript;

    // Use this for initialization
    void Start () {
        //Debug.Log(Camera.main.transform.position);
        autoCamScript = Camera.main.GetComponent<UnityStandardAssets.Cameras.AutoCam>();
        //Debug.Log(autoCamScript.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void changeRooms( Room room ) {
        autoCamScript.SetTarget(room.transform);
        Debug.Log("Changed Rooms");
        room.LoadRoom();

    }

    public static void resetRoom(Room room)
    {
        for (int i=0; i<room.enemies.Count; i++)
        {
            EnemyBehaviour enemy = room.enemies[i];
            enemy.transform.position = enemy.startPos;
            enemy.gameObject.SetActive(false);
        }
    }
}
