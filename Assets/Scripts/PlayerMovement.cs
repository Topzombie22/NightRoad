using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public bool IsGrounded;
    public float distToGround = 1f;
    public float gravity = -9.81f;

    public bool isTired;
    public bool isPressed;

    public float currentStamina = 100f;
    public float staminaUse = 20f;
    public float staminaRegen = 15f;

    public Transform groundCheck;

    public void Start()
    {

    }

    public void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
            if (IsGrounded == false)
            {
                transform.Translate(Vector3.up * gravity * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * 0 * Time.deltaTime);
            }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isPressed = false;
        }
        if (isPressed == true && currentStamina >= 0)
        {
            speed = 6f;
            currentStamina -= Time.deltaTime * staminaUse;
        }
        if (isPressed == false && currentStamina <= 100)
        {
            speed = 2f;
            currentStamina += Time.deltaTime * staminaRegen;
        }
        if(isTired == true)
        {
            speed = 2f;
        }
        
        if(currentStamina >= 15)
        {
            isTired = false;
        }
        else
        {
            isTired = true;
        }
    }

    IEnumerator Fatigue()
    {
            yield return new WaitForSeconds(1);
            currentStamina = currentStamina - staminaUse;

    }

    IEnumerator Rest()
    {
        yield return new WaitForSeconds(1);
        currentStamina = currentStamina + staminaRegen;
    }

}