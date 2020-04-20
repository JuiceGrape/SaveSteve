using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject EscMenu;
    public GameObject FailMenu;
    public GameObject SuccesMenu;
    public GameObject Immunities;

    public List<Spawner> Spawners;

    public Steve steve;

    public static bool[] completedLevels = new bool[15];

    void Start()
    {
        showAdventureImmunities();
    }

    public void ToggleEscMenu()
    {
        EscMenu.SetActive(!EscMenu.activeInHierarchy);

        if (EscMenu.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscMenu();
        }
    }

    public void DoneSpawning()
    {
        foreach(Spawner spawner in Spawners)
        {
            if (!spawner.IsDone())
            {
                return;
            }
        }

        if (steve.HungerList.Count  == 0)
        {
            StartCoroutine(SuccesAfter(2.0f));
        }
        else
        {
            steve.OnDeath();
        }
        
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Fail()
    {
        Time.timeScale = 0;
        FailMenu.SetActive(true);
    }

    public void Success()
    {
        Time.timeScale = 0;
        completedLevels[SceneManager.GetActiveScene().buildIndex] = true;
        SuccesMenu.SetActive(true);
    }

    IEnumerator SuccesAfter(float seconds)
    {
        yield return new WaitForSeconds(1);
        steve.Success();
        yield return new WaitForSeconds(seconds);
        Success();
    }

    public void showAdventureImmunities()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 9)
        {
            Immunities.SetActive(true);
        }
    }
}
