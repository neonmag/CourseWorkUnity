using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarkerTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject tooltip;

    private bool isActive =false;

    private void Start()
    {
        tooltip.SetActive(isActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = !isActive;
            tooltip.SetActive(isActive);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isActive = !isActive;
            tooltip.SetActive(isActive);
        }
    }
}
