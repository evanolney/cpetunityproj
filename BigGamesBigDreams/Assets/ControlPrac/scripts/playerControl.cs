using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed; //Player speed
    public float jumpStrength; // How hard the player jumps
 
    Animator animator;
    Rigidbody2D rbd2; //rigid body component for using physics
    SpriteRenderer spriteRenderer;

    public bool isgrounded;

    [SerializeField] //Manipulate in Unity 
    Transform GroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Better Update function?
    private void FixedUpdate()
    {
        if(Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }

        if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rbd2.velocity = new Vector2(-speed, rbd2.velocity.y);
            if(isgrounded)
                animator.Play("girl01_walk");
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
            if (isgrounded)
                animator.Play("girl01_walk");
            spriteRenderer.flipX = true;
        }
        else
        {
            if (isgrounded)
                animator.Play("girl01_idle");
            rbd2.velocity = new Vector2(0, rbd2.velocity.y);
        }

        if(Input.GetKey("space") && isgrounded)
        {
            animator.Play("girl01_jump");
            rbd2.velocity = new Vector2(rbd2.velocity.x, jumpStrength);
        }

    }
    /*
    // Update is called once per frame
    void Update()
    {

        
        float moveHorizontal = Input.GetAxis("Horizontal"); //horizontal input values
        float moveVertical;

        if (Input.GetKeyDown("space"))
        {
            moveVertical = jumpStrength;
        }
        else
        {
            moveVertical = 0;
        }
        //float moveVertical = Input.GetAxis("Vertical"); //Vertical input values

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Debug.Log(moveHorizontal);
        rbd2.AddForce(movement * speed);
    }
    */
}
