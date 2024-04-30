using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateQuestionMark : MonoBehaviour
{
    public float rotationSpeed = 150.0f;
    public float moveSpeed = 0.5f;
    public float height = 2.0f;
    private float initialHeight;
    void Start()
    {
        initialHeight = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        float newY = Mathf.PingPong(Time.time * moveSpeed, height) + initialHeight - height / 2.0f;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
