using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float moveSpeed;
    [SerializeField] GameManager gameManager;
    float verticalMove;
    [SerializeField] GameObject SpawnMonets;

    void Awake() {
        
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update() 
    {
        if (GameManager.start)
        {
            MoveCharacter();
        }  
    }
    void MoveCharacter()
    {
        verticalMove = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(transform.position.x, verticalMove * moveSpeed );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("money"))
        {
            Destroy(collision.gameObject);
            GameManager.coin++;
            GameManager.score += 1;
            gameManager.Increase();  
        }
        if (collision.gameObject.CompareTag("end"))
        {
            Destroy(gameObject);
            gameManager.Vin();
        }
    }
    /*
    void OnCollisionEnter2D(Collision2D collision) 
    {
        transform.position = new Vector2(-13.13f, -4.83f);
    }
    */

}
