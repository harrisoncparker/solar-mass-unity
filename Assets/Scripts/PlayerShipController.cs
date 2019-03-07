using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    public float rotationSpeed = 50;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
