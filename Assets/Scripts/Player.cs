/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;

/*
 * Simple Jump
 * */
public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            float jumpVelocity = 20f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement_FullMidAirControl();


        //Check if the player presses the "Interact key"
        if (Input.GetKeyDown(KeyCode.X))
        {
            Interact();
        }
    }


    void Interact()
    {
        GameObject[] interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject interactable in interactableObjects)
        {
            
            if (boxCollider2d.IsTouching(interactable.GetComponent<BoxCollider2D>()))
            {
                interactable.GetComponent<Interactable>().Interact();
            }

        }

        //RaycastHit2D interactObject = Physics2D.BoxCastAll();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement_FullMidAirControl()
    {
        float moveSpeed = 10f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                // No keys pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

}
