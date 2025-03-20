using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bau : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite levantandoSprite;
    public string moedaCorreta;
    public GameObject aviso;
    public int moedasNecessarias = 18; // Quantidade de moedas corretas necessárias para abrir o baú
    public string cenaFinal = "Completo"; // Nome da cena final

    private int tentativas = 0;
    private int moedasCertas = 0;
    private SpriteRenderer spriteRenderer;
    private bool moedaDentro = false;
    private GameObject moedaAtual;

    private PointEffector2D pointEffector;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        aviso.SetActive(false);
        pointEffector = GetComponent<PointEffector2D>();
        pointEffector.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moedas"))
        {
            spriteRenderer.sprite = levantandoSprite;
            moedaDentro = true;
            moedaAtual = other.gameObject;

            pointEffector.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Moedas"))
        {
            spriteRenderer.sprite = normalSprite;
            moedaDentro = false;

            pointEffector.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && moedaDentro)
        {
            Moedas moeda = moedaAtual.GetComponent<Moedas>();
            if (moeda != null)
            {
                if (moeda.tipo == moedaCorreta)
                {
                    moeda.transform.position = transform.position;
                    moeda.DesativarCollider();
                    Destroy(moeda.gameObject);
                    moedasCertas++; // Aumenta o contador de moedas corretas
                    spriteRenderer.sprite = normalSprite;
                    moedaDentro = false;
                    pointEffector.enabled = false;

                    // Verifica se todas as moedas corretas foram coletadas
                    if (moedasCertas >= moedasNecessarias)
                    {
                        SceneManager.LoadScene(cenaFinal);
                    }
                }
                else
                {
                    moeda.ResetarPosicao();
                    moeda.AtivarCollider();
                    tentativas++;
                    aviso.SetActive(true);
                    StartCoroutine(DesativarAviso());
                    if (tentativas >= 2)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
    }

    IEnumerator DesativarAviso()
    {
        yield return new WaitForSeconds(2);
        aviso.SetActive(false);
    }
}
