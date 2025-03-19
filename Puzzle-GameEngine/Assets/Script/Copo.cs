using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copo : MonoBehaviour
{
    public float targetWeight = 42f;
    public SpriteRenderer medidorSpriteRenderer;
    public Sprite[] medidorSprites;
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
        if (isBoxNear)
        {
            medidorSpriteRenderer.sprite = copoLevantadoSprite;
        }
        else
        {
            medidorSpriteRenderer.sprite = copoNormalSprite;
        }
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
        int spriteIndex = Mathf.Clamp((int)((currentWeight / targetWeight) * (medidorSprites.Length - 1)), 0, medidorSprites.Length - 1);
        medidorSpriteRenderer.sprite = medidorSprites[spriteIndex];

        if (currentWeight >= targetWeight)
        {
            Debug.Log("Peso Correto!");
        }
    }
}
