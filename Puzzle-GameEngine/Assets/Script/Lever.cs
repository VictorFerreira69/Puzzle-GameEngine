using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject esteira;
    private bool jogadorPerto = false;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite abaixado;
    private SpriteRenderer spriteRenderer;
    private bool alavancaAbaixada = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normal;
    }

    private void Update()
    {
        if (jogadorPerto && Input.GetButtonDown("Fire1"))
        {
            
            esteira.GetComponent<Esteira>().AlternarVelocidade();
            Debug.Log("Velocidade da esteira alterada!");

            
            alavancaAbaixada = !alavancaAbaixada;
            spriteRenderer.sprite = alavancaAbaixada ? abaixado : normal;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}