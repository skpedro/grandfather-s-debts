using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolll : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] Transform enemy;

    [SerializeField] float speed;
    private Vector3 itinScale;
    private bool moveLeft;

    private void Awake()
    {
        itinScale = enemy.localScale;
    }

    private void Update()
    {
        if (moveLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

     private void DirectionChange()
    {
        moveLeft = !moveLeft;
    }

    private void MoveInDirection(int _direction)
    {
        enemy.localScale = new Vector3(Mathf.Abs(itinScale.x) * _direction, itinScale.y,itinScale.z);
        enemy.position = new Vector3(enemy.position.x+Time.deltaTime*_direction*speed, enemy.position.y, enemy.position.z);
    }
}
