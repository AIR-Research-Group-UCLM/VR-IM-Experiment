using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;
using TMPro;
using System;
using System.Linq;
using Unity.VisualScripting;

public class VoiceIntentController : MonoBehaviour
{
    [Header("Voice")] [SerializeField] private AppVoiceExperience appVoiceExperience;

    [Header("UI")] [SerializeField] private TextMeshProUGUI debugText;

    private bool appVoiceActive;

    private void Awake()
    {
        appVoiceExperience.TranscriptionEvents.OnFullTranscription.AddListener((transcription) =>
        {
            debugText.text = transcription;
        });
    }

    void Start()
    {
        appVoiceExperience.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbrirCarrito()
    {
        Debug.Log("Carrito abierto");
    }
    
    public void CerrarCarrito()
    {
        Debug.Log("Carrito abierto");
    }

    public void BuscarProducto(String[] info)
    {
        foreach (var piece in info)
        {
            Debug.Log(piece);
        }
        Debug.Log("Se ha buscado el producto: ");
    }
}
