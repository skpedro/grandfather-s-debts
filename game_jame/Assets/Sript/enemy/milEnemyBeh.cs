using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milEnemyBeh : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float attackCooldown;
    [SerializeField] float range;
    [SerializeField] float colliderDistance;
    [SerializeField] int damage;

    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask playerMask;
    RaycastHit2D hit;
    private Animator anim;
    private Transform player;

    public GameObject point;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {   
        if (PlayerInSight())
        {
            Angry();  
        }

    }

    private bool PlayerInSight()
    {
         hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerMask);
        
        return hit.collider !=null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }


    void Angry()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, 0), player.position, speed * Time.deltaTime);
    }
}
