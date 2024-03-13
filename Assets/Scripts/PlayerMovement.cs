using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveDelay = 0;
    
    Vector3 movement = new();

    bool hasReducedInterval = false;

    void Start() {
    
    }
    void Update()
    {
        movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)){
            movement = new Vector3(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.S)){
            movement = new Vector3(0, -2, 0);
        }
        if (Input.GetKey(KeyCode.A)){
            movement = new Vector3(-2, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)){
            movement = new Vector3(2, 0, 0);
        }
        if (movement.magnitude == 0 && !hasReducedInterval){
            moveDelay = moveDelay/2;
            hasReducedInterval = true;
        }
        if (moveDelay > 0){
            moveDelay -= 1*Time.deltaTime;
        }
        if (moveDelay <= 0 && movement.magnitude > 0){
            transform.Translate(movement);
            movement = new Vector3(0, 0, 0);
            moveDelay = 0.5f;
            hasReducedInterval = false;
        }
    }
}
