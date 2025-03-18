using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] float speedX = 5;
    [SerializeField] float jumpForce = 200;
    [SerializeField] float addForceSpeed = 10;  // Velocidade para o modo AddForce
    private float horizontal;
    private bool isGrounded = true;
    private float groundCheckRadius = 0.2f;
    private bool useAddForce = false;  // Flag para determinar o modo de movimentação
    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        float speed = Mathf.Abs(horizontal);
        if (speed < 0.01f) speed = 0;
        animator.SetFloat("Speed", speed);

        // Flip do personagem
        if (horizontal < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else if (horizontal > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        if (useAddForce)
        {
            MoveWithAddForce();
        }
        else
        {
            MoveNormally();
        }

        // Verificação de chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Atualiza a animação de pulo
        if (rb.velocity.y == 0 && !isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void MoveNormally()
    {
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            rb.velocity = new Vector2(horizontal * speedX, rb.velocity.y);
        }
    }

    void MoveWithAddForce()
    {
        rb.AddForce(new Vector2(horizontal * addForceSpeed, 0), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }

        // Ativa o modo AddForce ao colidir com o Surface Effector
        if (collision.gameObject.CompareTag("SurfaceEffector"))
        {
            useAddForce = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

        // Desativa o modo AddForce ao sair do Surface Effector
        if (collision.gameObject.CompareTag("SurfaceEffector"))
        {
            useAddForce = false;
        }
    }
}