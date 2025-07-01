using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barimpulse : MonoBehaviour
{
    public float torqueStrength = 50f; // Adjust in Inspector

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ApplyTorque(-1); // Clockwise
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ApplyTorque(1); // Anti-clockwise
        }
    }

    void ApplyTorque(int direction)
    {
        // direction: -1 for clockwise, 1 for anti-clockwise
        Vector3 torque = Vector3.up * direction * torqueStrength;
        rb.AddTorque(torque, ForceMode.Impulse);
    }
}
