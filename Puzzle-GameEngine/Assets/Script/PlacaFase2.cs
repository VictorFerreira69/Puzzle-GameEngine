using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlacaFase2 : MonoBehaviour
{
    [SerializeField] private GameObject painelDialogo;
    [SerializeField] private TMP_Text textoDialogo; 
    [SerializeField] private string charada;
    [SerializeField] private Button botaoSair;
    [SerializeField] private GameObject jogador; 
    [SerializeField] private GameObject[] alavancas;
    private PlayerMove playerMove; 
    private bool jogadorPerto = false;

    void Start()
    {
        painelDialogo.SetActive(false);
        botaoSair.gameObject.SetActive(false);
        textoDialogo.gameObject.SetActive(false);
        botaoSair.onClick.AddListener(SairDoDialogo);
        playerMove = jogador.GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E) && !painelDialogo.activeSelf) 
        {
            MostrarCharada();
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

    private void MostrarCharada()
    {
        painelDialogo.SetActive(true);
        botaoSair.gameObject.SetActive(true); 
        textoDialogo.gameObject.SetActive(true);
        textoDialogo.text = charada;

        foreach (GameObject alavanca in alavancas)
        {
            alavanca.SetActive(false);
        }

        if (playerMove != null)
        {
            playerMove.enabled = false;
        }
    }

    private void SairDoDialogo()
    {
        painelDialogo.SetActive(false);
        botaoSair.gameObject.SetActive(false);
        textoDialogo.gameObject.SetActive(false);

        foreach (GameObject alavanca in alavancas)
        {
            alavanca.SetActive(true);
        }

        if (playerMove != null)
        {
            playerMove.enabled = true;
        }
    }
}
