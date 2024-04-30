using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed = 5.0f;

    private void Update()
    {
        transform.RotateAround(target.position, Vector3.down, rotationSpeed * Time.deltaTime);
    }
}
