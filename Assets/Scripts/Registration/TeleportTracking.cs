using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using Oculus.Interaction.Input.Editor.Generated;
using UnityEngine;

public class TeleportTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsHovered { get; set; }

    private Dictionary<GameObject, float> startTime= new Dictionary<GameObject, float>();
    private TeleportDataManager dataManager;
    [SerializeField] private GameObject hmd;
    public bool wasTP { get; set; }
    
    void Start()
    {
        dataManager = FindObjectOfType<TeleportDataManager>();
        wasTP = false;
    }

    void Update()
    {
        if(IsHovered)
        {
            if (!startTime.ContainsKey(gameObject))
            {
                startTime[gameObject] = Time.time;
            }

        }
        else if(startTime.ContainsKey(gameObject))
        {
            float duration = Time.time - startTime[gameObject];
            float timestamp = Time.time;
            string data = $"{timestamp}, {gameObject.name}, {hmd.transform.position.x}, {hmd.transform.position.y}, " +
                          $"{hmd.transform.position.z}, {duration}, {wasTP}";

            dataManager.AddTPData(data);
            startTime.Remove(gameObject);
        }
    }
}
