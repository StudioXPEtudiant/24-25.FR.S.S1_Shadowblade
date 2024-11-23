using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    public CharacterController Cac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cac.isGrounded)
        {
            Debug.Log(" sol toucher");
        }
        else 
        {
            if (Cac.velocity.y > 0)
            {
                Debug.Log("PLayer jump");
            }
            else
            {
                Debug.Log("player fall");
            }
        }
    }
}
