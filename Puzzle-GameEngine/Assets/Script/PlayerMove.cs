using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speedX = 5;
    [SerializeField] float jumpForce = 200;
    [SerializeField] float swimsForce = 250;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Fire3"))
        {
            rb.AddForce(new Vector2(0, -swimsForce));
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void FixedUpdate()// Para o uso da  Fisica
    {
        rb.AddForce(new Vector2(horizontal * speedX,  0), ForceMode2D.Force);
    }
   


}
