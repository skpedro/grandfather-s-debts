using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private bool move;
    [SerializeField] float rangex_f;
    [SerializeField] float rangex_b;
    [SerializeField] float speed;

    void FixedUpdate()
    {
        if (transform.position.x>rangex_f)
        {
            move = false;
        }
        if (transform.position.x < rangex_b)
        {
            move = true;
        }
        if (move)
        {
            transform.position = new Vector2(transform.position.x+speed*Time.fixedDeltaTime,transform.position.y);
        }
        if (!move)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
        }
    }
}
