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
    public float radius = 5.0F;
    public float power = 10000.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.detectCollisions = false;
    }
    void Update()
    {
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
        CheckExplosion();
    }
    void CheckExplosion()
    {
        //if e is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //explosion happens on character's position
            Vector3 explosionPos = transform.position;
            //detects how many colliders are hit within radius
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            // for each collider
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                //push them away with explosion force
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 100.0F);
                }
            }

            Debug.Log("Explosion triggered");
        }
    }
    /*void CheckKick()
    {
        //if k is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            //explosion happens on character's position
            Vector3 kickPos = transform.position;
            //detects how many colliders are hit within radius
            Collider[] colliders = Physics.OverlapCube(kickPos, radius);
            // for each collider
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                //push them away with explosion force
                if (rb != null)
                {
                    rb.AddExplosionForce(power, kickPos, radius, 100.0F);
                }
            }

            Debug.Log("Kick triggered");
        }
    }*/
}
