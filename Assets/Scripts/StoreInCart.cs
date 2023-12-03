using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInCart : MonoBehaviour
{
    // Lista de colliders con los que se puede interactuar
    public Collider[] interactableColliders;
    private ShoppingCartTrackerManager dataManager;
    private void Start()
    {
        dataManager = FindObjectOfType<ShoppingCartTrackerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el collider está en la lista de interactuables
        foreach (var interactableCollider in interactableColliders)
        {
            if (other == interactableCollider)
            {
                other.transform.SetParent(this.transform.parent);
                float timestamp = Time.time;
                string objectName = other.gameObject.name;
                string data = $"{timestamp}, {objectName}";

                dataManager.AddShoppingData(data);
                
            }
        }
    }
}
