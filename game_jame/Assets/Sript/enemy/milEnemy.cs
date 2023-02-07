using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float attackCooldown;
    [SerializeField] float range;
    [SerializeField] float colliderDistance; 
    [SerializeField] int damage;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask playerMask;
    [SerializeField] Rigidbody2D rbEnemy;
    private Animator anim;
    private Transform player;
    private float cooldowTimer = Mathf.Infinity;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        cooldowTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            Angry();
            anim.SetBool("Run",true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x*range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,Vector2.left,0,playerMask);

        return hit.collider;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    void Angry()
   {
       transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,0), player.position, speed * Time.deltaTime);
   }
}
