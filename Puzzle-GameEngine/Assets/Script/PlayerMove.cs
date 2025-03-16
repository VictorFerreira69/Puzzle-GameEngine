using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] float speedX = 5;
    [SerializeField] float jumpForce = 200;
    [SerializeField] float swimsForce = 250;
    private float horizontal;
    private bool isGrounded = true;
    private float groundCheckRadius = 0.2f;
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

        // Lógica para animação de movimento
        float speed = Mathf.Abs(horizontal);
        if (speed < 0.01f) speed = 0;
        animator.SetFloat("Speed", speed);

        // Flipar o personagem de acordo com a direção
        if (horizontal < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else if (horizontal > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

        // Pular
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }

        // Nadar (Força para baixo)
        if (Input.GetButtonDown("Fire3"))
        {
            rb.AddForce(new Vector2(0, -swimsForce));
        }
    }

    void FixedUpdate()
    {
        // Movimento horizontal
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            rb.AddForce(new Vector2(horizontal * speedX, 0), ForceMode2D.Impulse);
        }

        // Verifica se o personagem está no chão (com base em um raio de verificação)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Atualiza o estado da animação com base na velocidade vertical
        if (rb.velocity.y == 0 && !isGrounded)
        {
            animator.SetBool("IsJumping", false); // Garantir que a animação de pulo termine
        }
    }

    // Verifica a colisão com o chão para ajustar a animação e o estado de pulo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false); // Finaliza a animação de pulo
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true); // Define que o personagem está no ar
        }
    }
}