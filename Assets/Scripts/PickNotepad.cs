using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickNotepad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HorrorState.collectedNotepads++;
            HorrorState.valueOfScarring += 5;
            GameObject.Find("NotepadsCollected").GetComponent<TextMeshProUGUI>().text = $"{HorrorState.collectedNotepads}/15";
            GameObject.Find("ValueOfScarring").GetComponent<TextMeshProUGUI>().text = $"{HorrorState.valueOfScarring}/100";
            if(HorrorState.collectedNotepads == 15)
            {
                SceneManager.LoadScene(1);
            }
            Destroy(this.gameObject);
        }
    }
}
