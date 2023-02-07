using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForse;
    [SerializeField] float radiusCheck;

    public static int money;

    private float move;

    private bool facRight = true;
    private bool _isGraund;
    private bool _isPlatform;
    private bool dead;

    [SerializeField] Transform graundCheck;
    [SerializeField] Transform PlatformCheck;
    [SerializeField] LayerMask whatGround;
    [SerializeField] LayerMask whatPlatform;
    [SerializeField] GameObject mainPlatform;
    [SerializeField] AudioClip clipJump;

    private Vector2 v_Jump ;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audio;
    
    [SerializeField] GameManager gameManager;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("Volume");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Run();
        Flip();
    }
    void Update()
    {
        
        Jump();
        Spusk();
    }

    private void Run()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed*Time.fixedDeltaTime, rb.velocity.y);
        if (move==0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }
    }

    private void Jump()
    {
      
        _isGraund = Physics2D.OverlapCircle(graundCheck.position, radiusCheck, whatGround);
        if (Input.GetKeyDown(KeyCode.Space) && (_isGraund||_isPlatform))
        {
            audio.PlayOneShot(clipJump);
            rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
            //rb.velocity = Vector2.up * jumpForse;
            anim.SetTrigger("Jump");
        }
    }
    private void Spusk()
    {
        _isPlatform = Physics2D.OverlapCircle(PlatformCheck.position, radiusCheck, whatPlatform);
        if (Input.GetKeyDown(KeyCode.S)&& _isPlatform)
        {
            mainPlatform.GetComponent<PlatformEffector2D>().rotationalOffset=180;
            StartCoroutine(WaitPlatform());
        }
    }
    IEnumerator WaitPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        mainPlatform.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
        
    }
    private void FlipLogic()
    {
        facRight = !facRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Flip()
    {
        if (!facRight && move > 0)
        { FlipLogic(); }

        else if (facRight && move < 0)
        { FlipLogic(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("veg"))
        {
            Debug.Log(money);
            Destroy(collision.gameObject);
            GameManager.score += 1;
            gameManager.Increase();
           
        }
        if (collision.gameObject.CompareTag("end"))
        {
            Destroy(gameObject);
            gameManager.Vin();
        }
        if (collision.gameObject.CompareTag("end3"))
        {
            Destroy(gameObject);
            gameManager.End();
        }
    }
}
