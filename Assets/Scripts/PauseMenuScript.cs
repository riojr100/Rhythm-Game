using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public void onContinueClick()
    {
        PauseMenu.SetActive(false);
    }
    public void onRetryClick()
    {
        SceneManager.LoadScene("GoofyTiles");
    }
    public void onExitToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        StaticData.chartToPick = "";
    }
}
