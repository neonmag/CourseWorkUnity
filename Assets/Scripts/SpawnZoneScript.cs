using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnEnemy;

    private float currentTime = 0f;
    private float spawnRate = 1f; 

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnRate)
        {
            currentTime = 0f;
            Instantiate(spawnEnemy);
        }
    }
}
