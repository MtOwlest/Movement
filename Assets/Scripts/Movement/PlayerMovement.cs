using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rnsped;
    [SerializeField] float maxsped;
    [SerializeField] float placeHolder;
    Rigidbody2D rb;
    [SerializeField] public Vector2 MoveH;
    public Vector2 jumpForce;
    [SerializeField] private Vector2 playerScale;
    public float slippy;
    public bool isSliding;
    public Vector2 scale;
    


    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        transform.localScale = playerScale;

    }

    public void Update()
    {
        MoveH = new Vector2(Input.GetAxis("Horizontal"), 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce);
        }

    }
    public void FixedUpdate()
    {
        playerMove(MoveH);
        
        
    }

    //moveDirection is = to your movement, which were using as -1, or 1 with "Horizontal" and then we * that by the speed u have rn, or (rnsped)
    public void playerMove(Vector2 moveDirection)
    {

        //movement
        rnsped = Mathf.MoveTowards(rnsped, moveDirection.x * maxsped, placeHolder);

        rb.velocity = new Vector2(rnsped * moveDirection.x, rb.velocity.y);


        

        //sliding by pressing control, should output "Slipping"
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rnsped = slippy + rnsped;
            rb.velocity = new Vector2(moveDirection.x * rnsped, rb.velocity.y);
            Debug.Log("Slipping");
            isSliding = true;
            scale = new Vector2(0, 0.5f);
            playerScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Slipping");
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("Slipping");
        }


        else
        {
            rnsped = 5;
            isSliding = false;
            playerScale = scale * 2;
        }

        

    }
}
