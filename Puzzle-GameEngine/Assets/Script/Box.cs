using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float weight;
    private bool beingDragged;

    void Update()
    {
        if (beingDragged)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    void OnMouseDown()
    {
        beingDragged = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseUp()
    {
        beingDragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
