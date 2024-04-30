using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private float playerVelocityY; // вертикальна компонента швидкості
    private float gravityValue = -9.80f;
    private float jumpHeight = 1.0f;
    private bool groundedPlayer;

    private CharacterController _characterController;

    private Animator animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerVelocityY = 0f;

    }
    void Update()
    {
        groundedPlayer = _characterController.isGrounded;
        if (groundedPlayer && playerVelocityY < 0)
        {
            playerVelocityY = 0f;
        }

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if(dx > 0 && Mathf.Abs(dy) <= 0)
        {
            animator.SetTrigger("Right");
        }
        else if(dx < 0 && Mathf.Abs(dy) <= 0)
        {
            animator.SetTrigger("Left");
        }
        else if(dy > 0 && Mathf.Abs(dx) <= 0)
        {
            animator.SetTrigger("Forward");
        }
        else if (dy < 0 && Mathf.Abs(dx) <= 0)
        {
            animator.SetTrigger("Backward");
        }
        else if(Mathf.Abs(dx) <= 0.3 && Mathf.Abs(dy) <= 0.3)
        {
            animator.SetTrigger("Idle");
        }
        if (Mathf.Abs(dx) > 0 && Mathf.Abs(dy) > 0)
        {
            dx *= 0.707f; // /= Mathf.Sqrt(2f);
            dy *= 0.707f; // /= Mathf.Sqrt(2f);
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocityY += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            animator.SetTrigger("Jump");
        }
        // Camera.main.transform.forward - має нахил, иому для .Move має піднімальний ефект
        Vector3 horizontalForward = Camera.main.transform.forward;
        horizontalForward.y = 0;
        horizontalForward = horizontalForward.normalized;

        playerVelocityY += gravityValue * Time.deltaTime;

        Vector3 step = Time.deltaTime *
            (speed * (dx * Camera.main.transform.right + dy * horizontalForward) +
            playerVelocityY * Vector3.up);

        Debug.Log(step);
        _characterController.Move(step);
        this.transform.forward = horizontalForward;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter: " + other.gameObject.name);
        if (other.CompareTag("Floor"))
        {
            groundedPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit: " + other.gameObject.name);
        if (other.CompareTag("Floor"))
        {
            groundedPlayer = false;
        }
    }
}
