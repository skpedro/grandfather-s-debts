using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int hp = 3;
    [SerializeField] Image currentHp;

    [SerializeField] float iFrameDuration;
    [SerializeField] int numbOffFlashes;
    [SerializeField] GameManager gameManager;

    private SpriteRenderer spRend;

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(10, 11, false);
        spRend = GetComponent<SpriteRenderer>();
    }

    private void Damage()
    {
        hp--;
        currentHp.fillAmount -= 0.35f;
        StartCoroutine(Invunerability());
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cars"))
        {
            Damage();
            if (hp <= 0)
            {
                gameManager.Dead();
                Physics2D.IgnoreLayerCollision(10, 11, false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("water"))
        {
            Damage();
            transform.position = new Vector2(-2.51f, -4);
            if (hp <= 0)
            {
                gameManager.Dead();
                Destroy(gameObject);
                Physics2D.IgnoreLayerCollision(10, 11, false);
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
            if (hp <= 0)
            {
                gameManager.Dead();
                Physics2D.IgnoreLayerCollision(10, 11, false);             
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numbOffFlashes; i++)
        {
            spRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration/(numbOffFlashes*2));
            spRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numbOffFlashes * 3));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
