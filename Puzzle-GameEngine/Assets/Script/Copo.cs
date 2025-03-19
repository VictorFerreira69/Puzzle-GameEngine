using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copo : MonoBehaviour
{
    public float targetWeight = 42f;
   
    private float currentWeight;

    public Sprite copoNormalSprite;
    public Sprite copoLevantadoSprite;
    private bool isBoxNear = false;

    void Start()
    {
        isBoxNear = false; // Garantir que começa sem a caixa próxima
    }

    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Box box = other.GetComponent<Box>();
        if (box != null)
        {
            currentWeight += box.weight;
            UpdateWeightUI();
            if (!isBoxNear)
            {
                isBoxNear = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Box box = other.GetComponent<Box>();
        if (box != null)
        {
            currentWeight -= box.weight;
            UpdateWeightUI();
            if (isBoxNear)
            {
                isBoxNear = false;
            }
        }
    }

    void UpdateWeightUI()
    {
       

        if (currentWeight >= targetWeight)
        {
            Debug.Log("Peso Correto!");
        }
    }
}
