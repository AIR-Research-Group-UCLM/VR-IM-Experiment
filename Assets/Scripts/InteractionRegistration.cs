using System;
using TMPro;
using UnityEngine;

public class InteractionRegistration : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public TextMeshProUGUI debugTextTeleport;
    // Start is called before the first frame update

    public void Register(GameObject product)
    {
        // Obtener la fecha y hora actual
        DateTime now = DateTime.Now;

        // Crear el formato personalizado
        string format = "yyyy-MM-dd HH:mm:ss.ffffff";

        // Generar el timestamp con el formato deseado
        string timestamp = now.ToString(format);

        debugText.text = timestamp + " " + product.name + " " +  "manipulación";
    }

    public void RegisterTeleport(GameObject zone)
    {
        // Obtener la fecha y hora actual
        DateTime now = DateTime.Now;

        // Crear el formato personalizado
        string format = "yyyy-MM-dd HH:mm:ss.ffffff";

        // Generar el timestamp con el formato deseado
        string timestamp = now.ToString(format);

        string prefix = "TeleportHotspot";
        string zoneName = zone.name.Substring(prefix.Length);
        debugTextTeleport.text = timestamp + " " + zoneName + " " +  "teleport";
    }

    public void ClearDebugText()
    {
        debugText.text = "";
    }
}
