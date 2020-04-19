using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Adventurer> adventurers;

    public float delay = 2.0f;

    void Start()
    {
        StartSpawning();
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
            Instantiate(adventurer.gameObject, transform.position, Quaternion.identity); 
        }
    }

}


