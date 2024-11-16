using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject Image;
    public float Minspeed = 6f;

    public float jumpspeed = 8f;

    public float gravity = 20f;

    public float MaxSpeed = 15f;

    private float speed;

    public float wait;
    
    private Vector3 moveD = Vector3.zero;
    CharacterController Cac;

    void Start()
    {
        Cac = GetComponent<CharacterController>();
        speed = Minspeed;
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
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = MaxSpeed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = Minspeed;
            }

            if (!Cac.isGrounded)
            {
                if (Cac.velocity.y > 0)
                {
                    Debug.Log("ne touche plus le sol, saut");
                }
                else if (Cac.velocity.y < 0)
                {
                    Debug.Log("ne touche pas le sol, il tombe");
                }
                else
                {
                    Debug.Log("touche le sol");
                }
                
            }
            
        }

        moveD.y -= gravity * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);

        Cac.Move(moveD * Time.deltaTime);
    }

    public IEnumerator Waittime()
    {
        yield return new WaitForSeconds(wait);
    }
}