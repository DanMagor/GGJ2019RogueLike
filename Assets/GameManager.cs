using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static UnityStandardAssets.Cameras.AutoCam autoCamScript;
    public static bool reachedRitualRoom = false;
    public static List<Room> rooms;
    public Transform startingRoomSpawnpoint, ritualRoomSpawnpoint;
    public Room startingRoom, ritualRoom;

    private void Awake()
    {
        rooms = new List<Room>();
    }

    // Use this for initialization
    void Start () {
        autoCamScript = Camera.main.GetComponent<UnityStandardAssets.Cameras.AutoCam>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void changeRooms( Room room ) {
        //autoCamScript.SetTarget(room.transform);
        //Debug.Log("Changed Rooms");
        Camera.main.transform.position = room.transform.position + new Vector3(0,0,-10);
        room.LoadRoom();

    }

    public static void resetRoom(Room room)
    {
        for (int i=0; i<room.enemies.Count; i++)
        {
            EnemyBehaviour enemy = room.enemies[i];
            if (enemy.startPos != Vector3.zero)
            {
                enemy.transform.position = enemy.startPos;
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
}
