using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelSelect = null;
    [SerializeField] private GameObject MainMenuOptions = null;
    [SerializeField] private GameObject Credits = null;
    [SerializeField] private string cinematicName;

    public static int previousLevel = 0;

    private void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        if (previousLevel == 0)
        {
            LoadLevel(cinematicName);
        }
        else
        {
            LoadLevel(previousLevel);
        }
        
    }

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void EndlessMode()
    {

    }

    public void ShowLevelSelect()
    {
        LevelSelect.SetActive(true);
        MainMenuOptions.SetActive(false);
        Credits.SetActive(false);
    }

    public void ShowMainMenu()
    {
        LevelSelect.SetActive(false);
        MainMenuOptions.SetActive(true);
        Credits.SetActive(true);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

}
