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

    public static bool hasSeenCinematic = false;

    private void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        if (!hasSeenCinematic)
        {
            LoadLevel(cinematicName);
            hasSeenCinematic = true;
        }
        else
        {
            for(int i = 1; i < GameMenu.completedLevels.Length; i++)
            {
                if (!GameMenu.completedLevels[i])
                {
                    LoadLevel(i);
                    return;
                }   
            }
            LoadLevel(cinematicName);
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
