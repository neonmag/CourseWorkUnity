using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        this.transform.rotation = Camera.main.transform.rotation;
        rb.AddForce(Camera.main.transform.forward * 50f, ForceMode.Impulse);

        StartCoroutine(BreakBullet());
    }

    private IEnumerator BreakBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
