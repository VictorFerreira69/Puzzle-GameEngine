using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject esteira;
    private bool jogadorPerto = false;
    [SerializeField] Sprite normal;
    [SerializeField] Sprite abaixado;
    private void Start()
    {
        normal = GetComponent<Sprite>();    
    }
    private void Update()
    {
        if (jogadorPerto && Input.GetButtonDown("Fire1"))
        {
            esteira.GetComponent<Esteira>().AlternarVelocidade();
        
           
           Debug.Log("Velocidade da esteira alterada!");
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