using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Rigidbody2D rb;
    public float jumpForce = 3f;
    public bool isOnGround = true;

    public float speed = 10f;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }


        animator.SetFloat("walk", Mathf.Abs(horizontalInput));


        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            animator.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("dance");
        }



    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("jump", true);
        }
    }
}
