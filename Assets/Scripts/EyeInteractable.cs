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

    private Dictionary<GameObject, float> startTime= new Dictionary<GameObject, float>();
    private EyeTrackerDataManager dataManager;
    
    [SerializeField]
    private GameObject eyeGazeLeft;
    [SerializeField]
    private GameObject eyeGazeRight;
    
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
        }
        else if(startTime.ContainsKey(gameObject))
        {
            float duration = Time.time - startTime[gameObject];
            float timestamp = Time.time;
            string data = $"{timestamp}, {gameObject.name}, {gameObject.transform.parent.name}, {duration}, " +
                          $"{eyeGazeLeft.transform.position.x}, {eyeGazeLeft.transform.position.y}, " +
                          $"{eyeGazeLeft.transform.position.z}, {eyeGazeLeft.transform.rotation.x}, " +
                          $"{eyeGazeLeft.transform.rotation.y}, {eyeGazeLeft.transform.rotation.z}, " +
                          $"{eyeGazeRight.transform.position.x}, {eyeGazeRight.transform.position.y}, " +
                          $"{eyeGazeRight.transform.position.z}, {eyeGazeRight.transform.rotation.x}, " +
                          $"{eyeGazeRight.transform.rotation.y}, {eyeGazeRight.transform.rotation.z}";

            dataManager.AddCollisionData(data);
            startTime.Remove(gameObject);
        }
    }
}
