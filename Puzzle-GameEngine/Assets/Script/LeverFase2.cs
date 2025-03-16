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
    [SerializeField] private List<string> identificadoresCorretos;

    private static int alavancasErradas = 0;
    private static bool paredeDesativada = false;
    private static bool trampolimAtivado = false;

    void Start()
    {
        spriteRendererr = GetComponent<SpriteRenderer>();
        spriteRendererr.sprite = normall;
    }

    void Update()
    {
        if (jogadorPerto && Input.GetButtonDown("Fire1"))
        {
            if (!alavancaAbaixadas)
            {
                alavancaAbaixadas = true;
                spriteRendererr.sprite = abaixo;

                if (identificadoresCorretos.Contains(identificador))
                {
                    if (identificador == "parede")
                    {
                        DesativarParede();
                        paredeDesativada = true;
                    }
                    else if (identificador == "trampolim")
                    {
                        AtivarTrampolim();
                        trampolimAtivado = true;
                    }

                    // Verificar se as duas alavancas corretas foram ativadas
                    if (paredeDesativada && trampolimAtivado)
                    {
                        SumirAlavancasErradas();
                    }
                }
                else
                {
                    alavancasErradas++;

                    if (alavancasErradas >= 2)
                    {
                        ResetarAlavancasErradas();
                    }
                }
            }
        }
    }

    private void ResetarAlavancasErradas()
    {
        LeverFase2[] todasAsAlavancas = FindObjectsOfType<LeverFase2>();

        foreach (LeverFase2 alavanca in todasAsAlavancas)
        {
            if (!alavanca.identificadoresCorretos.Contains(alavanca.identificador))
            {
                alavanca.alavancaAbaixadas = false;
                alavanca.spriteRendererr.sprite = alavanca.normall;
            }
        }

        alavancasErradas = 0;
    }

    private void SumirAlavancasErradas()
    {
        LeverFase2[] todasAsAlavancas = FindObjectsOfType<LeverFase2>();

        foreach (LeverFase2 alavanca in todasAsAlavancas)
        {
            if (!alavanca.identificadoresCorretos.Contains(alavanca.identificador))
            {
                alavanca.gameObject.SetActive(false);
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

    private void AtivarTrampolim()
    {
        if (trampolim != null)
        {
            trampolim.SetActive(true);
        }
    }

}
   