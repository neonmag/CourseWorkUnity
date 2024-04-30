using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    [SerializeField]
    private GameObject light;
    private bool activeLight = false;
    private AudioSource m_audioSource;
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        light.SetActive(activeLight);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && HorrorState.isFlashlightPicked)
        {
            activeLight = !activeLight;
            light.SetActive(activeLight);
            m_audioSource.Play();
        }
    }
}
