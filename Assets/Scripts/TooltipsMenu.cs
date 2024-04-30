using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject tooltipNotes;
    [SerializeField]
    private GameObject firstNote;
    public void CloseElement()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(tooltipNotes);
        Destroy(firstNote);
    }
}
