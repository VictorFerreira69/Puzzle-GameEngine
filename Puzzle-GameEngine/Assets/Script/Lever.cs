using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject esteira;
    Esteira alternar;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           
            esteira.GetComponent<Esteira>().AlternarVelocidade();
            Debug.Log("Velocidade da esteira alterada!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
           
           
        }
    }
}