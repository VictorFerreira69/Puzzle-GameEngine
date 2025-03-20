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
    private BoxCollider2D boxCollider;
    private bool estaEmCima = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(TrocarSprite());
    }

    IEnumerator TrocarSprite()
    {
        while (true)
        {
            if (estaEmCima)
            {
                spriteRenderer.sprite = espinhoBaixo;
                boxCollider.enabled = true;  
            }
            else
            {
                spriteRenderer.sprite = espinhoCima;
                boxCollider.enabled = false; 
            }

            estaEmCima = !estaEmCima;
            yield return new WaitForSeconds(tempoTroca);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
