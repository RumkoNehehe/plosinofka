using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoktorkoController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float speed2;
    [SerializeField] float jumpForce;
    private bool isGrounded;
    private bool isJumping;


    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed2 = 1;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {

        float moveInput = Input.GetAxis("Horizontal");


        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.Space))))
        {
            anim.SetTrigger("takeOf");
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            isJumping = true;
        }

        if (isJumping)
        {
            anim.SetBool("isJumping", true);
            isJumping = false;
        }
        if(isGrounded && !isJumping)
        {
            anim.SetBool("isJumping", false);
            
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed2 = 2;
        }
        else
        {
            speed2 = 1;
        }


       rb.velocity = new Vector2(moveInput * speed* speed2, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
       else if(moveInput != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", true);

        }
        else 
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
        }




        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(moveInput > 0) 
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        
        if(collision.gameObject.tag == "cajocka")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameController.instance.triggerDoktorkoDestroyed.Invoke();
    }
}
