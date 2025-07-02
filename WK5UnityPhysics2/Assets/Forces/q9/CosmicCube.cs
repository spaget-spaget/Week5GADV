using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicCube : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer cubeRenderer;

    void Start()
    {
        //get the cube renderer
        cubeRenderer = GetComponent<Renderer>();
    }
    //on hit
    void OnCollisionEnter(Collision collision)
    {
        //turn green
        cubeRenderer.material.color = Color.green;
    }

    void OnCollisionExit(Collision collision)
    {
        //turn red on hit
        cubeRenderer.material.color = Color.red;
    }
    // similar to Update() or Start(), OnCollisionEnter() and OnCollisionExit() works when the cube hits something or leaves something, without needing the code to detect hitting or leaving.
}
