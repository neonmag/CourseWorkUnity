using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlightScript : MonoBehaviour
{
    [SerializeField]
    private GameObject flashLightAnchor;
    [SerializeField]
    private GameObject flashLight;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject spawnedFlashLight = Instantiate(flashLight);
            spawnedFlashLight.transform.parent = flashLightAnchor.transform;

            spawnedFlashLight.transform.localPosition = new Vector3(0, 0, 0);

            spawnedFlashLight.transform.localRotation = Quaternion.identity;
            spawnedFlashLight.transform.localScale = new Vector3(1, 1, 1);

            HorrorState.isFlashlightPicked = true;

            Destroy(this.gameObject);
        }
    }
}
