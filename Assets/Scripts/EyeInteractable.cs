using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class EyeInteractable : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField] 
    private UnityEvent<GameObject> OnObjectHovered;

    [SerializeField] private TextMeshProUGUI debugText;
    private Dictionary<GameObject, float> startTime= new Dictionary<GameObject, float>();
    private EyeTrackerDataManager dataManager; 
    
    void Start()
    {
        dataManager = FindObjectOfType<EyeTrackerDataManager>();
    }

    void Update()
    {
        if(IsHovered)
        {
            if (!startTime.ContainsKey(gameObject))
            {
                startTime[gameObject] = Time.time;
            }

            Debug.Log("Has visto: " + this.name);
            OnObjectHovered?.Invoke(gameObject);
            debugText.text = "Has visto: " + this.name;
        }
        else if(startTime.ContainsKey(gameObject))
        {
            float duration = Time.time - startTime[gameObject];
            float timestamp = Time.time;
            string data = $"{timestamp}, {gameObject.name}, {gameObject.transform.parent.name}, {duration}";

            dataManager.AddCollisionData(data);
            startTime.Remove(gameObject);
        }
    }
}
