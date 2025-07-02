using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float impulseForce = 10f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //get rigi
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //trigger ApplyImpulse function with direction forward
            ApplyImpulse(Vector3.forward);
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
