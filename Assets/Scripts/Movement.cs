using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 moveForce;              
    public float moveSpeed = 80f;
    public float maxSpeed = 80f;
    public float drag = 0.98f;

    public float strength = 30f;

    private bool boostPhase;
    public float boostAmount = 1.2f;

    public GameObject startText;
    public GameObject instructions;
    public GameObject gameOverUI;
    public GameObject timeUpUI;

    bool gameOver;

    float timeTrk;

    private void Start()
    {
        boostPhase = false;
        timeTrk = 0;
        gameOver = false;
    }

    private void Update()
    {
        if (gameOver)           //return if game state is over
        {
            return;
        }

        timeTrk += Time.deltaTime;
        if (Input.GetMouseButton(0)) 
        {
            if (startText.activeInHierarchy)
                startText.SetActive(false);
            if (instructions.activeInHierarchy)
            {
                instructions.SetActive(false);
            }

            if (boostAmount > 0)
                moveForce += transform.forward * moveSpeed * Time.deltaTime;        //move force is calculated velocity in actuality

            if (boostPhase)
            {
                if (boostAmount > 0)
                    boostAmount -= Time.deltaTime;
                Debug.Log(boostAmount);

                
            }
        }

        if (boostAmount <= 0 && moveForce == Vector3.zero)                          //if the car comes to stop
        {
            gameOverUI.SetActive(true);
            gameOver = true;
        }
        else if(timeTrk > 32f)                                                      //or if time runs out
        {
            timeUpUI.SetActive(true);
            gameOver = true;
        }
        //Debug.Log(moveForce);
    }

    void FixedUpdate()
    {
        transform.position += moveForce * Time.deltaTime;                           
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);                    //move force to not exceed max specified value

        if (moveForce.y < 1f && moveForce.z < 1f)
        {
            moveForce = Vector3.zero;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")                                   //give some force on collision with ground
        {
            if(strength > 0)
            {
                moveForce += Vector3.up * strength;
                moveForce += Vector3.forward * strength;
                strength -= 6;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ramp")
        {
            boostPhase = true;
            Debug.Log(boostPhase);
        }
    }
}