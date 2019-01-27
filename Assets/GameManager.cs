using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static UnityStandardAssets.Cameras.AutoCam autoCamScript;
    public static bool reachedRitualRoom = false;
    public static List<Room> rooms;
    public Transform startingRoomSpawnpoint, ritualRoomSpawnpoint;
    public Room startingRoom, ritualRoom;

    public static int itemsRemaining = 0;

    private void Awake()
    {
        rooms = new List<Room>();
    }

    // Use this for initialization
    void Start () {
        if (autoCamScript != null)
        {
            autoCamScript = Camera.main.GetComponent<UnityStandardAssets.Cameras.AutoCam>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void changeRooms( Room room ) {
        //autoCamScript.SetTarget(room.transform);
        //Debug.Log("Changed Rooms");
        Camera.main.transform.position = room.transform.position + new Vector3(0,0,-10);
        PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (player.bringingObject)
        {
            player.bringingObject = false;
            player.item = null;
        }
        room.LoadRoom();

    }

    public static void resetRoom(Room room)
    {
        for (int i=0; i<room.enemies.Count; i++)
        {
            EnemyBehaviour enemy = room.enemies[i].GetComponent<EnemyBehaviour>();
            if (enemy.startPos != Vector3.zero)
            {
                enemy.gameObject.transform.position = enemy.startPos;
            }
            
            enemy.gameObject.SetActive(false);
        }
    }

    public static void arriveRitualRoom()
    {
        reachedRitualRoom = true;
    }

    public void respawn() {

        for (int i=0; i<rooms.Count; i++)
        {
            resetRoom(rooms[i]);
        }

        Transform player = GameObject.FindWithTag("Player").transform;
        if (reachedRitualRoom)
        {
            player.position = ritualRoomSpawnpoint.position;
            changeRooms(ritualRoom);
        } else
        {
            player.position = startingRoomSpawnpoint.position;
            changeRooms(startingRoom);
        }
    }

    public static void checkItems ()
    {
        if (itemsRemaining == 0)
        {
            Debug.Log("Collected all the items!");
        }
    }

}
