using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {
    public float speed = 1;

    public GameObject player;

    // Use this for initialization
    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update() {
        if (player.GetComponent<LanternSwitcher>().LightIsOn()) {
            transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }

    }
}
