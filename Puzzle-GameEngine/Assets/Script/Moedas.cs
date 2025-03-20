using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moedas : MonoBehaviour
{
    public string tipo;
    private Vector3 posicaoInicial;
    private bool sendoArrastada;
    private Collider2D meuCollider;

    void Start()
    {
        posicaoInicial = transform.position;
        meuCollider = GetComponent<Collider2D>();  
    }

    void OnMouseDown()
    {
        sendoArrastada = true;
    }

    void OnMouseDrag()
    {
        if (sendoArrastada)
        {
            transform.position = GetMouseWorldPosition();
        }
    }

    void OnMouseUp()
    {
        sendoArrastada = false;
    }

    public void ResetarPosicao()
    {
        transform.position = posicaoInicial;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void DesativarCollider()
    {
        meuCollider.enabled = false; 
    }

    public void AtivarCollider()
    {
        meuCollider.enabled = true; 
    }
}