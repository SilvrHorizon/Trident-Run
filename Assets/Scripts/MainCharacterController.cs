using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{


    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    //The layers that the player can jump uppon.
    [SerializeField] LayerMask jumpableLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Handle "Controlls"
        ControlledMovement();



    }

    //The velocity that the player gets when jumping
    [SerializeField] float jumpHeight = 15f;

    //The horizontal velocity it gets when A or D is pressed 
    [SerializeField] float horizontalSpeed = 6.5f;

    //The vector that the player volontarily moves the character
    void ControlledMovement()
    {
        Vector2 direction = new Vector2();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Make sure the player cant hold on to a wall by going into it
            if (Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.left, 0.1f, jumpableLayerMask).collider == null)
            {
                rigidbody2D.velocity = new Vector2(-horizontalSpeed, rigidbody2D.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.D))

        {   
            //Make sure the player cant hold on to a wall by going into it
            if (Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.right, 0.1f, jumpableLayerMask).collider == null)
            {
                rigidbody2D.velocity = new Vector2(horizontalSpeed, rigidbody2D.velocity.y);
            }
        }
    }

    //True if the player is touching ground.
    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableLayerMask);
        if (raycastHit2D.collider != null)
        {
            return true;
        }
        return false;
    }

}
