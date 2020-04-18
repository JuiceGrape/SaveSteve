using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject LevelSelect;
    [SerializeField] private GameObject MainMenuOptions;

    private void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        LoadLevel(1);
    }

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void EndlessMode()
    {

    }

    public void ShowLevelSelect()
    {
        LevelSelect.SetActive(true);
        MainMenuOptions.SetActive(false);
    }

    public void ShowMainMenu()
    {
        LevelSelect.SetActive(false);
        MainMenuOptions.SetActive(true);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

}
