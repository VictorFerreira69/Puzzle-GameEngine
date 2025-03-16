using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFase2 : MonoBehaviour
{
   private bool jogadorPerto = false;
   [SerializeField] private Sprite normall;
   [SerializeField] private Sprite abaixo;
   private SpriteRenderer spriteRendererr;
   private bool alavancaAbaixadas = false;
   [SerializeField] private string identificador; 
   [SerializeField] private GameObject parede;   
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
       if (parede != null)
       {
           parede.SetActive(false);
       }
   }

   private void AtivarParede()
   {
       if (parede != null)
       {
           parede.SetActive(true);
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
