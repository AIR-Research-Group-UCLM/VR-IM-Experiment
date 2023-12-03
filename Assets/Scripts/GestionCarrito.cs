using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionCarrito : MonoBehaviour
{
    [SerializeField] private Sprite productoImg;

    [SerializeField] private GameObject canvasContent;

    [SerializeField] private GameObject prefabItemCart;
    
    public void AddToCart()
    {
        // Instancia el prefab
        GameObject instance = Instantiate(prefabItemCart, canvasContent.transform);

        // Encuentra el hijo con el componente Image y asigna la imagen
        Image childImage = instance.GetComponentInChildren<Image>();
        if (childImage != null)
        {
            childImage.sprite = productoImg;
        }

        // Hacer que el prefab instanciado sea hijo del parentObject
        instance.transform.SetParent(canvasContent.transform);
    }
}
