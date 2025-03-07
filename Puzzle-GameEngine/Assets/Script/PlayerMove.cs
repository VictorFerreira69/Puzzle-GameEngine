using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    [SerializeField] float speedX = 5;
    [SerializeField] float jumpForce = 200;
  //  [SerializeField] float swimsForce = 250;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
       // if (Input.GetButtonDown("Fire3"))
       // {
        //    rb.AddForce(new Vector2(0, -swimsForce));
       // }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

    }
    private void FixedUpdate()
    {
        if (horizontal != 0)
            rb.velocity = new Vector2(horizontal * speedX, rb.velocity.y);
    }
}
