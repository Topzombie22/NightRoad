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
    public float gravity = -9.81f;

    public bool isTired;
    public bool isPressed;

    public float currentStamina = 100f;
    public float staminaUse = 20f;
    public float staminaRegen = 15f;

    public bool faded = false;

    public Animator animate;

    public Slider Stam;
    public GameObject stambar;

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
        Stam.value = currentStamina;

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
            speed = 8f;
            currentStamina -= Time.deltaTime * staminaUse;
        }
        if (isPressed == false && currentStamina <= 100)
        {
            speed = 4f;
            currentStamina += Time.deltaTime * staminaRegen;
        }
        if(isTired == true)
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