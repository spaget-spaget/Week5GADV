using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Variables are declared here
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float explosionRadius = 5f;
    public float kickStrength = 500f;
    public float explosionForce = 100f;
    public float upwardsModifier = 0.5f;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.detectCollisions = false;
    }
    void Update()
    {
        CheckExplosion();
        CheckKick();
        //Player movement. 
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        //Gravity
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        
    }
    void CheckExplosion()
    {
        //if e is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 explosionPosition = transform.position;

            // Get all colliders within the explosion radius
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier, ForceMode.Impulse);
                }
            }

            Debug.Log("Explosion triggered");
        }
    }
    void CheckKick()
    {
        //if e is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 explosionPosition = transform.position;

            // Get all colliders within the explosion radius
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddForce(transform.forward * kickStrength, ForceMode.Impulse);
                    Debug.Log("Kick applied!");
                }
            }

        }
    }
}
