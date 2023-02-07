using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D rbEnemy;
    public Transform player;

    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();

    }

}
