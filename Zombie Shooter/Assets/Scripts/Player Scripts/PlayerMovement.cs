using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveForceX = 1.5f, moveForceY = 1.5f;

    private Rigidbody2D rb;
    private PlayerAnimations playerAnimation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0)
        {
            rb.velocity = new Vector2(moveForceX, rb.velocity.y);
        }
        else if (h < 0)
        {
            rb.velocity = new Vector2(-moveForceX, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (v > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveForceY);
        }
        else if (v < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveForceY);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        // Animate the player
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
            playerAnimation.PlayerRunAnimation(true);
        else if (rb.velocity.x == 0 && rb.velocity.y == 0)
            playerAnimation.PlayerRunAnimation(false);

        Vector3 tempScale = transform.localScale;
        if (h > 0)
            tempScale.x = -1;
        else if (h < 0)
            tempScale.x = 1;
        transform.localScale = tempScale;
    }
}
