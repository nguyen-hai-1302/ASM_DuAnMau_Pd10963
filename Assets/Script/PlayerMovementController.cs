using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer sprite;
    public AudioSource jumpSource;
    public AudioSource finishSource;
    public PlayerData playerData;

    private float dirX = 0f;    
    public float jumpForce;

    private bool isSliding = false;
    public float slidingSpeed = 10f;

    private bool isOnSwamp = false;

    private int Level = 1;

    private bool canDoubleJump = false;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Text levelText;   


    private enum MovementState {idle, running, jumping, falling };    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        if (isSliding)
        {
            rb.velocity = new Vector2(slidingSpeed, rb.velocity.y);
        }
        if (isOnSwamp)
        {
            // Ngăn player di chuyển
            dirX = 0f;
            rb.velocity = new Vector2(0, rb.velocity.y);            
        }
        Jump();
           
        UpdateAnimation();
        
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                jumpSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                jumpSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = false;
            }

        }
    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }       
        anim.SetInteger("state", (int)state);
    }    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, whatIsGround);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trampoline"))
        {            
            rb.velocity = new Vector2(rb.velocity.x, 14f);            
        }        
        if (col.gameObject.name.Equals("Finish"))
        {
            finishSource.Play();
            LoadNextScene();
            Level++;
            levelText.text = "Level: " + Level;
        }
        if (col.gameObject.CompareTag("Ice"))
        {
            isSliding = true;
        }
        if (col.gameObject.CompareTag("Swamp"))
        {
            isOnSwamp = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ice"))
        {
            isSliding = false;
        }
        if (col.gameObject.CompareTag("Swamp"))
        {
            isOnSwamp = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            Destroy(col.gameObject, 2f);
        }
        
    }
    //private void OnTriggerExit2D(Collider2D col)
    //{
        
    //}
    public void LoadNextScene()
    {
        playerData.playerLevel++;
        PlayerPrefs.SetInt("PlayerLevel",playerData.playerLevel);
        PlayerPrefs.SetInt("PlayerScore", playerData.playerScore);
        PlayerPrefs.SetInt("PlayerHeal", playerData.playerHeal);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
