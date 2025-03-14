using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float impulso = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, impulso);
        }
    }
}
