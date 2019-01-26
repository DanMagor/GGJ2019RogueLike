using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public Transform playerSpawnLoc;
    public List<EnemyBehaviour> enemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadRoom()
    {
        //Transform player = GameObject.FindWithTag("Player").transform;
        //player.position = playerSpawnLoc.position;

        for (int i = 0; i < enemies.Count; i++)
        {
            EnemyBehaviour enemy = enemies[i];
            enemy.transform.position = enemy.startPos;
            enemy.gameObject.SetActive(true);
        }
    }
}
