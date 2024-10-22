using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D playerRB;

    public float moveSpeed = 5F;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize;

    public float jumpForce = 13F;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerWalk();
        PlayerJump();
    }
    private void PlayerWalk()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0F)
        {
            playerRB.velocity = new Vector2(moveSpeed, playerRB.velocity.y);
            ChangeSpriteDirection(0.8F);
        }
        else if (moveInput < 0F)
        {
            playerRB.velocity = new Vector2(-moveSpeed, playerRB.velocity.y);
            ChangeSpriteDirection(-0.8F);
        }
        else
            playerRB.velocity = new Vector2(0F, playerRB.velocity.y);

        playerAnim.SetInteger("Speed", Mathf.Abs((int)playerRB.velocity.x));
    }

    private void PlayerJump()
    {
        if (isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0.5F, groundLayer))

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }

        playerAnim.SetBool("isJumping", !isGrounded);
    }

    private void ChangeSpriteDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
}