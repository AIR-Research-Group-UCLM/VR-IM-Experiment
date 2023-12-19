using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ProductInteractionManager : MonoBehaviour
{
    private List<string> batchData = new List<string>();
    private float batchTimer = 8.0f;
    private string filePath;
    private static bool headerWritten = false;
    public string directoryName = "default";
    void Start()
    {
        
        string path = Path.Combine(Application.persistentDataPath, directoryName);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string sceneName = SceneManager.GetActiveScene().name;

        string fileName = "ProductInteractionData" + sceneName + ".csv";
        filePath = Path.Combine(path, fileName);
        StartCoroutine(BatchSaveCoroutine());
        if (!headerWritten)
        {
            AddCsvHeader();
            headerWritten = true;
        }
    }

    public void AddProductInteractionData(string data)
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
                writer.WriteLine("Timestamp, Object, Interactable, Position_x, Position_y, Position_y, Rotation_x, " +
                                 "Rotation_x, Rotation_x, Scale_x, Scale_y, Scale_z");
            }
        }
    }
    
    void OnDestroy()
    {
        SaveData(); // Guardar datos restantes al destruir el objeto
    }
}
