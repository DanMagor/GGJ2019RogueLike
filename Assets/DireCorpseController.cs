using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireCorpseController : MonoBehaviour
{
    public float Speed = 15.0f;


    private Animator animatorController;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        lastPlayerPosition = transform.position;
        animatorController = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        bool huntIsOn = player.GetComponent<LanternSwitcher>().LightIsOn();

        if (huntIsOn)
        {
            approachPlayer();
        }
    }

    private void approachPlayer()
    {
        if (isPlayerVisible())
        {
            lastPlayerPosition = player.transform.position;
        }

        if (lastPlayerPosition.x > transform.position.x)
        {
            animatorController.SetBool("MoveRight", true);
        }
        else
        {
            animatorController.SetBool("MoveRight", false);
        }
        transform.position = Vector3.MoveTowards(transform.position, lastPlayerPosition, Speed * Time.deltaTime);
    }

    private bool isPlayerVisible()
    {
        var dir = player.transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100.0f, LayerMask.GetMask("Wall"));
        return !hit;

    }

    private Vector3 lastPlayerPosition;
}
