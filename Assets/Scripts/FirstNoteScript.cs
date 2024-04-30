using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstNoteScript : MonoBehaviour
{
    [SerializeField]
    private GameObject helpNote;
    [SerializeField]
    private GameObject stats;
    [SerializeField]
    private TextMeshProUGUI statsText;
    [SerializeField]
    private TextMeshProUGUI statsValue;

    private bool active = false;
    void Start()
    {
        helpNote.SetActive(active);
        stats.SetActive(active);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            active = !active;
            helpNote.SetActive(active);
            stats.SetActive(active);
            HorrorState.collectedNotepads++;
            HorrorState.valueOfScarring+=5;
            statsText.text = $"{HorrorState.collectedNotepads}/15";
            statsValue.text = $"{HorrorState.valueOfScarring}/100";
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;
        }
    }
}
