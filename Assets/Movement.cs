using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float jump = 1;
    private Rigidbody2D rb;
    private bool isJumping;
    private bool switchSprite;
    // Start is called before the first frame update
    void Start()
    {
        switchSprite = false;
        isJumping = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            rb.AddForce(new Vector2(0, jump * rb.mass), ForceMode2D.Impulse);
            isJumping = true;
        }

        Debug.Log("isJumping:" + isJumping);
        gameObject.GetComponent<SpriteRenderer>().flipX = switchSprite;

    }
    private void FixedUpdate()
    {
        //float vertChange = 0;//rb.velocity.y + (rb.gravityScale * rb.mass);
        //onGround = gameObject.GetComponentInChildren<Foot>().grounded();
        //Input

        float horizontalInput = Input.GetAxis("Horizontal");

        // Movement direction calculation
        Vector2 move = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (horizontalInput < 0)
        {
            switchSprite = true;
        } else if (horizontalInput > 0)
        {
            switchSprite = false;
        }

        MovePlayer(move);
    }
    void MovePlayer(Vector2 movement)
    {
        //add force
        float smoothSpeed = 5f;
        rb.velocity = Vector2.Lerp(rb.velocity, movement, Time.fixedDeltaTime * smoothSpeed);
    }

    public void setJump()
    {
        isJumping = false;
    }
}
