using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{


    public float speed = 1;

    public PlayerController player;

    public GameManager gameManager;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.LightIsOn)
        {
            transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }

    }
}
