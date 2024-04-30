using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Slider enemySlider;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private GameObject objMenu;
    [SerializeField]
    private AudioMixer audioMixer;

    void Start()
    {
        LoadSettings();

        objMenu.SetActive(false);
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.GetFloat("enemyValue") != 0.0f)
        {
            enemySlider.value = PlayerPrefs.GetFloat("enemyValue");
            musicSlider.value = PlayerPrefs.GetFloat("musicValue");

            HorrorState.priestSpawnRate = enemySlider.value;
            HorrorState.musicVolume = musicSlider.value;
            audioMixer.SetFloat("Volume", HorrorState.musicVolume);
        }
    }

    public void EnemySliderChange()
    {
        HorrorState.priestSpawnRate = enemySlider.value;
    }

    public void MusicSliderChange()
    {
        HorrorState.musicVolume = musicSlider.value;
        audioMixer.SetFloat("Volume", HorrorState.musicVolume);
    }

    public void CloseButton()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        objMenu.SetActive(false);
    }

    public void SaveChanges()
    {
        PlayerPrefs.SetFloat("enemyValue", enemySlider.value);
        PlayerPrefs.SetFloat("musicValue", musicSlider.value);

        PlayerPrefs.Save();
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
