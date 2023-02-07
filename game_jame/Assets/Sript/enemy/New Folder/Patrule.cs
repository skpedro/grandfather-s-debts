using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrule : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveRight;
    private Transform player;
    public float stopDist;

    bool chill;
   // bool angry;
   // bool goBack;

    private bool facRight;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,point.position)<=positionOfPatrol )
        {
            chill = true;
        }
        if (chill == true)
        {
            Chill();
        }

        
    }

    void Chill()
    {
        if (transform.position.x>=point.position.x)
        {
            moveRight = false;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y);
        }
        if (transform.position.x <= point.position.x )
        {
            moveRight = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x+speed*Time.deltaTime,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }


}
