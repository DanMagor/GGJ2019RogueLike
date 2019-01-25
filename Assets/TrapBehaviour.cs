using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{

    public float speed = 30;

    public GameObject point1;
    public GameObject point2;



    private GameObject currentPoint;

    // Use this for initialization
    void Start()
    {
        currentPoint = point1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentPoint.transform.position) <= 0.1f)
        {
            currentPoint = currentPoint == point1 ? point2 : point1;
        }
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.transform.position, speed * Time.deltaTime);
        
    }
}
