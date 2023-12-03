using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class ProductInteractionTracker : MonoBehaviour
{
    public bool IsSelected { get; set; }
    private Dictionary<GameObject, float> interactions= new Dictionary<GameObject, float>();
    private ProductInteractionManager dataManager;
    private IInteractable interactionType;
    public bool wasTP { get; set; }
    
    void Start()
    {
        dataManager = FindObjectOfType<ProductInteractionManager>();
        wasTP = false;
        interactionType = gameObject.GetComponent<IInteractable>();
    }

    void Update()
    {
        if(IsSelected)
        {
            if (!interactions.ContainsKey(gameObject))
                interactions[gameObject] = Time.time;   
            
            float timestamp = Time.time;
            
            string data = $"{Time.time}, {gameObject.name}, {interactionType.ToString()}, {transform.position.x}, {transform.position.y}, " +
                          $"{transform.position.z}, {transform.rotation.x}, {transform.rotation.y}, " +
                          $"{transform.rotation.z}, {transform.localScale.x}, {transform.localScale.y}, {transform.localScale.z}";
            dataManager.AddProductInteractionData(data);
        }
        else
        {
            if (interactions.ContainsKey(gameObject))
            {
                interactions.Remove(gameObject);
                string data = $"{Time.time}, {gameObject.name}, {interactionType.ToString()}, {transform.position.x}, {transform.position.y}, " +
                              $"{transform.position.z}, {transform.rotation.x}, {transform.rotation.y}, " +
                              $"{transform.rotation.z}, {transform.localScale.x}, {transform.localScale.y}, {transform.localScale.z}";
                dataManager.AddProductInteractionData(data);
            }
        }
    }

}
