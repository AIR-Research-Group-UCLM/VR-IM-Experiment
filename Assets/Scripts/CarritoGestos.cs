using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarritoGestos : MonoBehaviour
{
    [SerializeField]
    private GameObject _curvedCanvas;

    private List<Image> _productosEnCarrito = new List<Image>();
    // Start is called before the first frame update
    public void AbrirCarrito()
    {
        _curvedCanvas.SetActive(true);
    }

    public void CerrarCarrito()
    {
        _curvedCanvas.SetActive(false);
    }

}
