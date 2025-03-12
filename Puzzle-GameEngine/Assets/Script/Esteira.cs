using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public float velocidadeNormal = -50f;
    public float velocidadeInvertida = 50f;
    private bool direcaoInvertida = false;
    void Start()
    {
        
        surfaceEffector = GetComponent<SurfaceEffector2D>();
       
        surfaceEffector.speed = velocidadeNormal;
    }
   
    public void AlternarVelocidade()
    {
        direcaoInvertida = !direcaoInvertida;
        surfaceEffector.speed = direcaoInvertida ? velocidadeInvertida : velocidadeNormal;
    }
}
