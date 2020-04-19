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
        menu.Spawners.Add(this);
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnAfter(0));
    }

    public void StartSpawningAfter(float seconds)
    {
        StartCoroutine(SpawnAfter(seconds));
    }

    IEnumerator SpawnAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        foreach(Adventurer adventurer in adventurers)
        {
            yield return new WaitForSeconds(delay);
            GameObject spawned = Instantiate(adventurer.gameObject, transform.position, Quaternion.identity); 
            spawnedAdventurers++;
            spawned.GetComponent<Adventurer>().SetSpawner(this);
        }
        doneSpawning = true;
    }

    public void RemoveAdventurer(GameObject adventurer)
    {
        spawnedAdventurers--;
        if (IsDone())
        {
            menu.DoneSpawning();
        }
    }

    public bool IsDone()
    {
        return doneSpawning && spawnedAdventurers == 0;
    }

}


