using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PriestScript : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;

    private Vector3 lastPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        lastPosition = player.transform.position;
        agent.SetDestination(player.transform.position);

        StartCoroutine(DestroyItself());
    }

    private IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    void Update()
    {
        if(player.transform.position != lastPosition)
        {
            agent.SetDestination(player.transform.position);
            lastPosition = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HorrorState.collectedNotepads = 0;
            HorrorState.valueOfScarring = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
