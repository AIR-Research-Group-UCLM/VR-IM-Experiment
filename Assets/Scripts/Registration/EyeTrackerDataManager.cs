using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class EyeTrackerDataManager : MonoBehaviour
{
    private List<string> batchData = new List<string>();
    private float batchTimer = 30.0f;
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

        string fileName = "EteTrackerData" + sceneName + ".csv";
        filePath = Path.Combine(path, fileName);
        StartCoroutine(BatchSaveCoroutine());
        if (!headerWritten)
        {
            AddCsvHeader();
            headerWritten = true;
        }
    }

    public void AddCollisionData(string data)
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
                writer.WriteLine("Timestamp, Object Name, Section, Collision Duration, EyeLeftPosition_x, " +
                                 "EyeLeftPosition_y, EyeLeftPosition_z, EyeLeftRotation_x, EyeLeftRotation_y, " +
                                 "EyeLeftRotation_z, EyeRightPosition_x, EyeRightPosition_y, EyeRightPosition_z," +
                                 "EyeRightRotation_x, EyeRightRotation_y, EyeRightRotation_z");
            }
        }
    }
    
    void OnDestroy()
    {
        SaveData(); // Guardar datos restantes al destruir el objeto
    }
}
