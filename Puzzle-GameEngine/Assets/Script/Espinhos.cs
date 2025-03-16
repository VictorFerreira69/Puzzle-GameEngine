using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Espinhos : MonoBehaviour
{
    public Sprite espinhoCima; 
    public Sprite espinhoBaixo; 
    public float tempoTroca = 1f;
    private SpriteRenderer spriteRenderer;
    private bool estaEmCima = true; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        StartCoroutine(TrocarSprite()); 
    }

    
    IEnumerator TrocarSprite()
    {
        while (true)
        {
            if (estaEmCima)
            {
                spriteRenderer.sprite = espinhoCima;
            }
            else
            {
                spriteRenderer.sprite = espinhoBaixo;
            }

            estaEmCima = !estaEmCima;
            yield return new WaitForSeconds(tempoTroca);
        }
    }

    // Detecta a colisão com o jogador
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player") && estaEmCima)
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}   