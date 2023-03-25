using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        body= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
        //player horizontal movement
        body.velocity = new Vector2( horizontalInput * speed ,body.velocity.y);

        //Flip player left and right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        // Player jump
        if (Input.GetKey(KeyCode.Space)&& Grounded)
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.LeftShift))
            body.velocity = new Vector2(horizontalInput * powerUpSpeed, body.velocity.y);

        // set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
    }

    //for player Jump
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        Grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.tag == "Ground")
        Grounded= true;
    }
    public bool CanAttack()
    {
        return horizontalInput == 0 && Grounded == true;
    }

    private Rigidbody2D body;
    private Animator anim;
   

    [SerializeField]
    private float speed;
    [SerializeField]
    private float powerUpSpeed;
    private bool Grounded;

    private float horizontalInput;



}
