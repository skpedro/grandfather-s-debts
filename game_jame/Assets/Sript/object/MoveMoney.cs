using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoney : MonoBehaviour
{
    public float monetSpeed;
    void Start()
    {
        transform.position = new Vector2(24f, Random.Range(-4.4f, -1.12f));
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * monetSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("zabor"))
        {
            GameManager.coin++;
            Destroy(gameObject);
        }
    }
}
