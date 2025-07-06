using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float force = 100f;
    public int direction = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            if (direction == 1)
            {
                rb.AddForce(firePoint.right * force);
                direction += 1;
            }
            else if (direction == 2)
            {
                rb.AddForce(-firePoint.right * force);
                direction += 1;
            }
            else if (direction == 3)
            {
                rb.AddForce(firePoint.up * force);
                direction += 1;
            }
            else if (direction == 4)
            {
                rb.AddForce(-firePoint.up * force);
                direction = 1;
            }
        }
    }
}
