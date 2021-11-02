using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public bool IsGrounded;
    public float distToGround = 1f;
    public float gravity = 9.81f;

    public bool isTired;
    public bool isPressed;

    public float overallSpeed;
    public float RunningSpeedCap;
    public float WalkingSpeedCap;
    public float currentStamina = 100f;
    public float staminaUse = 20f;
    public float staminaRegen = 15f;

    public bool faded = false;
    public bool inWater = false;

    public Animator animate;

    public Slider Stam;
    public GameObject stambar;

    public GameObject water;

    public void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Stam.value = currentStamina;
        overallSpeed = controller.velocity.magnitude;

        if(overallSpeed >= 4.01f && isPressed == false)
        {
            overallSpeed = 4.0f;
        }
        if (overallSpeed >= 4.01f && isPressed == true && currentStamina <= 1)
        {
            overallSpeed = 4.0f;
        }
        if (overallSpeed >= 8.01f && isPressed == true)
        {
            overallSpeed = 8.0f;
        }

        if (Stam.value >= 100 && faded == false)
        {
            stambar.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, true);
            faded = true;
        }
        if (Stam.value <= 99 && Stam.value >= 1)
        {
            stambar.GetComponent<Image>().CrossFadeAlpha(1, 1.0f, true);
            faded = false;
        }
        if(Stam.value <= 0)
        {
            stambar.GetComponent<Image>().CrossFadeAlpha(0, 1.0f, true);
        }
        Animations();

        if (Physics.Raycast(transform.position, Vector3.down, distToGround))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
            if (IsGrounded == false)
            {
                transform.Translate(Vector3.down * gravity * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * 0 * Time.deltaTime);
            }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isPressed = false;
        }
        if (isPressed == true && inWater == true)
        {
            speed = 5.2f;
        }
        else if (isPressed == true && inWater == false)
        {
            speed = 8f;
        }
        if (isPressed == false && inWater == true)
        {
            speed = 2.6f;
        }
        else if (isPressed == false && inWater == false)
        {
            speed = 4f;
        }
        if (currentStamina <= 100 && isPressed == false)
        {
            currentStamina += Time.deltaTime * staminaRegen;
        }
        if (currentStamina >= 0 && isPressed == true)
        {
            currentStamina -= Time.deltaTime * staminaUse;
        }
        if (isTired == true)
        {
            speed = 4f;
        }
        
        if(currentStamina >= 0 )
        {
            isTired = false;
        }
        else
        {
            isTired = true;
        }
    }

    void Animations()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animate.SetBool("Moving", false);
        }
        else
        {
            animate.SetBool("Moving", true);
        }
        if (isPressed == true && currentStamina >= 0.0f)
        {
            animate.SetBool("Running", true);
        }
        else
        {
            animate.SetBool("Running", false);
        }
    }
}