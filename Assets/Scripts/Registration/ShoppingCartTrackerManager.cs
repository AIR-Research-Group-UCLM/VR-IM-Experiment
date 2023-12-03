using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShoppingCartTrackerManager : MonoBehaviour
{
    private List<string> batchData = new List<string>();
    private float batchTimer = 42.0f;
    private string filePath;
    private static bool headerWritten = false;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "ShoppingCart.csv");
        StartCoroutine(BatchSaveCoroutine());
        if (!headerWritten)
        {
            AddCsvHeader();
            headerWritten = true;
        }
    }

    public void AddShoppingData(string data)
    {
        batchData.Add(data);
    }

    IEnumerator BatchSaveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(batchTimer);
            SaveData();
        }
    }

    void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (string data in batchData)
            {
                writer.WriteLine(data);
            }
        }
        batchData.Clear();
    }

    void AddCsvHeader()
    {
        if (!File.Exists(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Timestamp, ItemAdded");
            }
        }
    }
    
    void OnDestroy()
    {
        SaveData(); // Guardar datos restantes al destruir el objeto
    }
}
