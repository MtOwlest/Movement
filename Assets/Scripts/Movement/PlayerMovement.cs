// im a dumbass dont expect much, but this is made by me :)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rnsped;

    [SerializeField] float maxsped;

    Rigidbody2D rb;

    [SerializeField] public Vector2 MoveH;

    public Vector2 jumpForce;

    [SerializeField] private Vector2 playerScale;

    public float slippy;

    public bool isSliding;

    public Vector2 scale;

    public bool isJump;
    


    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        transform.localScale = playerScale;

    }

    public void Update()
    {
        MoveH = new Vector2(Input.GetAxis("Horizontal"), 0f);

        //Jumping coming soon!

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //isJump = true;
            //rb.AddForce(jumpForce);
        //}

    }
    public void FixedUpdate()
    {
        playerMove(MoveH);
        
        
    }

    //moveDirection is = to your movement, which were using as -1, or 1 with "Horizontal" and then we * that by the speed u have rn, or (rnsped)
    public void playerMove(Vector2 moveDirection)
    {

        //movement

        rb.velocity = new Vector2(rnsped * moveDirection.x, rb.velocity.y);


        

        //sliding by pressing control, should output "Slipping"
        if (isJump = true && Input.GetKey(KeyCode.LeftControl))
        {
            rnsped = slippy + rnsped;

            rb.velocity = new Vector2(rnsped * moveDirection.x, rb.velocity.y);

            isSliding = true;

            scale = new Vector2(0, 0.5f);

            playerScale = scale;
        }

        else
        {
            playerScale = scale * 2;
            isSliding = false;
            rnsped = 5;
        }




        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Start Slipping");
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("Stopped Slipping");

        }

        if (rb.velocity.magnitude > maxsped)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxsped);
        }

    }
}
