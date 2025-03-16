using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite portaNormal;
    [SerializeField] private Sprite portaAberta;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = portaNormal; 
    }

   
    public void AbrirPorta()
    {
        spriteRenderer.sprite = portaAberta; 
    }

  private void OnTriggerExit2D(Collider2D collision)
    {
        SceneManager.LoadScene("Fase2");
    }
}
