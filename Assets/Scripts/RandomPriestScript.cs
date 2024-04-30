using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPriestScript : MonoBehaviour
{
    [SerializeField]
    private GameObject priest;

    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= HorrorState.priestSpawnRate)
        {
            currentTime = 0f;
            int random = Random.RandomRange(0, 100 - HorrorState.valueOfScarring);
            if(random <= 50)
            {
                Instantiate(priest);
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                priest.transform.localPosition = new Vector3(player.transform.localPosition.x - 5, player.transform.localPosition.y, player.transform.localPosition.z - 5);
            }
        }
    }
}
