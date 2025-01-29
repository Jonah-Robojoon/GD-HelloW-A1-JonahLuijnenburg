using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4;
    public float rotationSpeed = 4;

    //Het animator component wordt hier gedefinieerd. 
    //Hierdoor kunnen we deze in verschillende functies in de class gebruiken.
    private Animator _animator;

    void Start()
    {
        //Het animator component wordt uit het object opgehaald.
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * movementSpeed * Time.deltaTime;
            _animator.SetFloat("speed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward * movementSpeed * Time.deltaTime;
            _animator.SetFloat("speed", 1);
        }

            transform.Rotate(0,Input.GetAxis("Horizontal")*rotationSpeed,0);
        
        transform.position += movement.normalized * movementSpeed * Time.deltaTime;
    }
}