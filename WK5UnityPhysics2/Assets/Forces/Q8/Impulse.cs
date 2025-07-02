using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float impulseForce = 10f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ApplyImpulse(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ApplyImpulse(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ApplyImpulse(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ApplyImpulse(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyImpulse(Vector3.up);
        }
    }
    void ApplyImpulse(Vector3 direction)
    {
        if (rb != null)
        {
            rb.AddForce(direction.normalized * impulseForce, ForceMode.Impulse);
        }
    }
}
