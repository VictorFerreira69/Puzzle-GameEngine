using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class LeverFase2 : MonoBehaviour
{
    private bool jogadorPerto = false;
    [SerializeField] private Sprite normall;
    [SerializeField] private Sprite abaixo;
    private SpriteRenderer spriteRendererr;
    private bool alavancaAbaixadas = false;
    [SerializeField] private string identificador;
    [SerializeField] private Tilemap paredeTilemap;
    [SerializeField] private GameObject trampolim;

    void Start()
    {
        spriteRendererr = GetComponent<SpriteRenderer>();
        spriteRendererr.sprite = normall;
    }

    void Update()
    {
        if (jogadorPerto && Input.GetButtonDown("Fire1"))
        {
            alavancaAbaixadas = !alavancaAbaixadas;
            spriteRendererr.sprite = alavancaAbaixadas ? abaixo : normall;

            switch (identificador)
            {
                case "parede":
                    if (alavancaAbaixadas)
                        DesativarParede();
                    else
                        AtivarParede();
                    break;

                case "trampolim":
                    if (alavancaAbaixadas)
                        AtivarTrampolim();
                    else
                        DesativarTrampolim();
                    break;

                default:
                    Debug.LogWarning("Alavanca sem ação definida: " + identificador);
                    break;
            }
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

    private void DesativarParede()
    {
        if (paredeTilemap != null)
        {
           
            TilemapCollider2D collider = paredeTilemap.GetComponent<TilemapCollider2D>();
            if (collider != null)
            {
                collider.enabled = false;
                
            }
           

           
            TilemapRenderer renderer = paredeTilemap.GetComponent<TilemapRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
               
            }
          
        }
    }

    private void AtivarParede()
    {
        if (paredeTilemap != null)
        {
            
            TilemapCollider2D collider = paredeTilemap.GetComponent<TilemapCollider2D>();
            if (collider != null)
            {
                collider.enabled = true;
              
            }
            

            
            TilemapRenderer renderer = paredeTilemap.GetComponent<TilemapRenderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
                
            }
           
        }
    }

    private void AtivarTrampolim()
    {
        if (trampolim != null)
        {
            trampolim.SetActive(true);
          
        }
    }

    private void DesativarTrampolim()
    {
        if (trampolim != null)
        {
            trampolim.SetActive(false);
           
        }
    }
}