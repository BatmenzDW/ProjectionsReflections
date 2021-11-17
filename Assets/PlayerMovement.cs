using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    public float movementSpeed = 5f;
    public void HandleMovement() {
    float moveX = 0f;
    float moveY = 0f;
    if (Input.GetKey(KeyCode.W))
    {
      moveY = +1f;
    }
    if(Input.GetKey(KeyCode.S))
    {
      moveY = -1f;
    }
    if (Input.GetKey(KeyCode.A))
    {
      moveX = -1f;
    }
    if (Input.GetKey(KeyCode.D))
    {
      moveX = +1f;
    }
    bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle)
        {
            
        }
        else
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            Vector3 targetMovePosition = transform.position + moveDir * movementSpeed * Time.deltaTime;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, movementSpeed * Time.deltaTime);
            if (raycastHit.collider == null)
            {
                transform.position = targetMovePosition;
            }
            else
            {
                //Don't move
                Vector3 testMoveDir = new Vector3(moveDir.x, 0f).normalized;
            }
        }
    }
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); // Can also use regular magnitude here, but less efficient
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
