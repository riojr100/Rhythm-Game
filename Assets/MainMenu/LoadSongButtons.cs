using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LoadSongs : MonoBehaviour
{
    public GameObject ParentPage;
    public GameObject buttonPrefab;
    void Start()
    {
        // string path = Path.Combine(Application.dataPath, "Charts/");
        string folderPath = Path.Combine(Application.dataPath, "Charts");
        // string folderPath = "Assets/Charts/";
        ScanFolder(folderPath);
        // var button = Instantiate(buttonPrefab, ParentPage.transform);
        // button.transform.SetParent(ParentPage.transform);
    }

    void ScanFolder(string path)
    {
        if (!Directory.Exists(path))
        {
            Debug.LogError($"The folder at path '{path}' does not exist!");
            return;
        }

        // Get all files in the folder with .loler extension
        string[] lolerFiles = Directory.GetFiles(path, "*.loler", SearchOption.TopDirectoryOnly);

        // Debug.Log($"Found {lolerFiles.Length} .loler files in folder: {path}");

        // Log file names
        foreach (string file in lolerFiles)
        {
            var newButton = Instantiate(buttonPrefab, ParentPage.transform);
            newButton.name = Path.GetFileNameWithoutExtension(file);
            TextMeshProUGUI buttonTextComponent = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonTextComponent != null)
            {
                buttonTextComponent.name = Path.GetFileName(file);
                buttonTextComponent.text = Path.GetFileNameWithoutExtension(file);
            }

            Button buttonComponent = newButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => OnButtonClick(Path.GetFileNameWithoutExtension(file)));
            }
            // Debug.Log($"Loler File: {Path.GetFileName(file)}, {Path.GetFileNameWithoutExtension(file)}");
        }
    }
    private void OnButtonClick(string fileName)
    {
        SceneManager.LoadScene("GoofyTiles");
        StaticData.chartToPick = fileName;
    }
}
