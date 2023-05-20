using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private Animator anim;
    public Rigidbody rb;

    private float horizontal;
    private bool isFacingRight = true;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interacting");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        if(move.magnitude > 0)
        {
            anim.SetBool("IsMoving", true);
        } else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        // This is used to rotate the 3D Character, Might not use due to sprite
        //transform.rotation = Quaternion.Slerp(trasnform.rotation, Quaternion.LookRotation(movement), 0.15f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (movement.magnitude == 0)
        {
            anim.SetBool("IsMoving", false);
        }
        else
        {
            anim.SetBool("IsMoving", true);
            if (movement.x > 0 && !isFacingRight)
            {
                // Flip the sprite if the player is moving to the right but is not facing right
                isFacingRight = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (movement.x < 0 && isFacingRight)
            {
                // Flip the sprite if the player is moving to the left but is not facing left
                isFacingRight = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
