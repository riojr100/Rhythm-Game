using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Tooltip("Menus")]
    public GameObject MainPage;
    public GameObject SongPage;


    public void PlayButton()
    {
        MainPage.SetActive(false);
        SongPage.SetActive(true);
    }

    public void BackToMainPage()
    {
        MainPage.SetActive(true);
        SongPage.SetActive(false);
    }

    public void ExitButton()
    {
        // Works in built application
        Application.Quit();

        // For debugging in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
