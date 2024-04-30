using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    private float speed = 10f;

    void Update()
    {
        this.transform.Rotate(Vector3.up, Time.deltaTime * speed);        
    }
}
