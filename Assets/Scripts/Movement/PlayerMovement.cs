// im a dumbass dont expect much,
//this is made completely by me and i tried making it super easy to edit and learn from.
//good stats would be 10 maxspeed, 300-500 jumpForce, and slippy = 0.2f


//just the libraries were using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //just initilazing some values ya know

    //speed
    [SerializeField] private float rnsped;

    //max speed
    [SerializeField] float maxsped;

    //making the rigidbody called rb so we can reference it easier
    Rigidbody2D rb;

    //gives a value on the x axis
    [SerializeField] public Vector2 MoveH;

    //the force in which we jump
    public Vector2 jumpForce;

    //the scale of the player (it doesnt work)
    [SerializeField] private Vector2 playerScale;

    //ur slide speed
    public float slippy;

    //true or false for if sliding or not
    public bool isSliding;

    //the scale (which doesnt work)
    public Vector2 scale;

    //true of false for if jumping or not
    public bool isJump;


    

    //its called before anything in Update() is called
    public void Start()
    {
        //making our variable rb/our rigidbody = to the rigid body on our character
        rb = this.GetComponent<Rigidbody2D>();

        //making scale = player scale we set. (Doesnt work)
        transform.localScale = playerScale;

        //make sure at the start u cant jump
        isJump = false;
    }

    public void Update()
    {
        //using old input, were using MoveH the var we defined set = to a vector which is between -1, or 1 on the x axis, which is interpreted by the axis Horizontal
        MoveH = new Vector2(Input.GetAxis("Horizontal"), 0f);

        //if is jump = true or were touching ground, and they press space, then we add a force which is = to jumpforce.
        if (isJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            isSliding = false;
            isJump = false;
            //where we use our rigidbody and add some force to that which is = to jumpforce variable
            rb.AddForce(jumpForce);
        }
        
    }
    public void FixedUpdate()
    {
        //using our method, and then calling our movement, which we multiply everything by.
        playerMove(MoveH);
    }

    public void playerMove(Vector2 moveDirection)
    {

        //movement

        //moveDirection is = to your movement, which were using as -1, or 1 with "Horizontal" and then we * that by the speed u have rn, or (rnsped)

        rb.velocity = new Vector2(rnsped * moveDirection.x, rb.velocity.y);


        

        //sliding by pressing control, should output "Slipping"
        if (isJump == true && Input.GetKey(KeyCode.LeftControl))
        {
            //also if sliding is true then u can slide, so no sliding in air!
            if (isSliding == true)

            {//current speed is equal to our slip speed + current speed
                rnsped = slippy + rnsped;

                //doing new velocity with our new speed
                rb.velocity = new Vector2(rnsped * moveDirection.x, rb.velocity.y);

                //makes the bool isSliding = to true
                isSliding = true;

                //sets scale to what sohuld be half but its not
                scale = new Vector2(0, 0.5f);

                //making our old var playerScale = to our new scale
                playerScale = scale;
            }
        }

        else
        {
            //setting everything to default if its not.
            playerScale = scale * 2;
            isSliding = false;
            rnsped = 5;
        }


        //debuigging to make sure it works :)

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Start Slipping");
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("Stopped Slipping");

        }

        //clamps to make it so if speed is over maxspeed, then its = to the maxsped
        if (rnsped > maxsped)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxsped);
            //makes rnsped = to maxsped
            rnsped = maxsped;
            //logging it
            Debug.Log(rb.velocity);
        }

    }

    //if we enter collision with another object
    public void OnCollisionEnter2D(Collision2D collision)
    {

        //if our collisions gameobjects layer is 12 or our ground layer then make is jump true so we can jump.
        if (collision.gameObject.layer == 12)
        {
            isJump = true;
            isSliding = true;
            //Debug.Log(isJump);
        }

    }

    //if still touching then isJump will still be true
    public void OnCollisionStay2D(Collision2D collision)
    {
        isJump = true;
        isSliding = true;
        //Debug.Log(isJump);
    }
    
    //as soon as u exit it then u will not be able to jump
    public void OnCollisionExit2D(Collision2D collision)
    {
        isJump = false;
        isSliding = false;
        //Debug.Log(isJump);
    }
}
