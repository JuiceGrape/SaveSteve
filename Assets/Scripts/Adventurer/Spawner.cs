using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Adventurer> adventurers;

    public float delay = 2.0f;

    public int spawnedAdventurers;

    public GameMenu menu;

    public bool doneSpawning = false;

    void Start()
    {
        StartSpawning();
        menu.Spawners.Add(this);
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnWithFrequency(delay));
    }

    IEnumerator SpawnWithFrequency(float timing)
    {
        foreach(Adventurer adventurer in adventurers)
        {
            yield return new WaitForSeconds(timing);
            GameObject spawned = Instantiate(adventurer.gameObject, transform.position, Quaternion.identity); 
            spawnedAdventurers++;
            spawned.GetComponent<Adventurer>().SetSpawner(this);
        }
        doneSpawning = true;
    }

    public void RemoveAdventurer(GameObject adventurer)
    {
        spawnedAdventurers--;
        Debug.Log("Time to begin");
        if (IsDone())
        {
            Debug.Log("Isn't it");
            menu.DoneSpawning();
        }
    }

    public bool IsDone()
    {
        return doneSpawning && spawnedAdventurers == 0;
    }

}


