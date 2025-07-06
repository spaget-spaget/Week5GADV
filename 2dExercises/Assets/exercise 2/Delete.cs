using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("wall")) return;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
