using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
   
    void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X") * 2;
        float y = -Input.GetAxis("Mouse Y");

        // vertical tilting
        float yClamped = transform.eulerAngles.x + y;
        transform.rotation = Quaternion.Euler(
                                yClamped,
                                transform.eulerAngles.y,
                                transform.eulerAngles.z);
        // horizontal orbiting
        transform.RotateAround(
                        new Vector3(0, 3, 0),
                        Vector3.up, x);
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(
                                        projectilePrefab,
                                        transform.position,
                                        transform.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddRelativeForce(new Vector3(0, 0, 2000));
        }
    }

}
