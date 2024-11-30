using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
  
    [Header("SPEED")]
    public float Minspeed = 6f;

    public float jumpspeed = 100f;
    
    public float MaxSpeed = 15f;

    private float speed;

    [Header("Andurance")]
    public float andurance;
    public float anduranceMin;
    public float anduranceMax;

    [Header("Le Reste")]
    public float gravity = 20f;

    private Vector3 moveD = Vector3.zero;
    
    CharacterController Cac;

    public Slider slider;
    
    public float wait;
    void Start()
    {
        Cac = GetComponent<CharacterController>();
        speed = Minspeed;
        andurance = anduranceMax;
        slider.maxValue = anduranceMax;
        slider.minValue = anduranceMin;
        slider.value = andurance;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Cac.isGrounded)
        {
            moveD = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;
            
            
            if (Input.GetButton("Jump"))
            {
                moveD.y = jumpspeed;
               // Cac.SimpleMove(Vector3.up * jumpspeed);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = MaxSpeed;
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = Minspeed;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                andurance += -1f * Time.deltaTime;
            }

            if (andurance <= anduranceMin)
            {
                andurance = anduranceMin;
                speed = Minspeed;
            }

         
           

            if (andurance >= anduranceMax)
            {
                andurance = anduranceMax;
            }

            slider.value = andurance;
        }
        else
        {
            moveD.y -= gravity * Time.deltaTime;
        }

        
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);
       Cac.Move(moveD * Time.deltaTime);
    }

    
}