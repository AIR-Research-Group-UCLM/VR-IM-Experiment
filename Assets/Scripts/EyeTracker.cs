using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public class EyeTracker : MonoBehaviour
{
    [SerializeField]
    private float rayDistance = 1.0f;
    [SerializeField]
    private float rayWidth = 0.01f;

    [SerializeField]
    private LayerMask layersToInclude;
    
    [SerializeField]
    private Color rayColorDefault = Color.yellow;
    
    [SerializeField]
    private Color rayColorHover = Color.blue;

    private List<EyeInteractable> eyeInteractables = new List<EyeInteractable>();

    private float timer = 0f;

    private void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 raycastDirection = transform.TransformDirection(Vector3.forward) * rayDistance;

        if (Physics.Raycast(transform.position, raycastDirection, out hit, Mathf.Infinity, layersToInclude))
        {
            // If something is already selected, unselect it first
            UnSelect();
            Debug.Log("Hitee el objeto : " + hit.transform.gameObject.name);
            var eyeInteractable = hit.transform.GetComponent<EyeInteractable>();
            eyeInteractables.Add(eyeInteractable);
            eyeInteractable.IsHovered = true;
        }
        else
        {
            UnSelect(true);
        }
    }

    // Update is called once per frame
    void UnSelect(bool clear = false)
    {
        foreach (var interactable in eyeInteractables)
        {
            interactable.IsHovered = false;
        }

        if (clear)
        {
            eyeInteractables.Clear();
        }
    }
}
