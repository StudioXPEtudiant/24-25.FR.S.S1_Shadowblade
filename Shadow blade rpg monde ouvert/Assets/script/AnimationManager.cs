using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public float detection;
    public CharacterController Cac;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up * detection, Color.red);
        if (Physics.Raycast(transform.position, transform.up, out hit, detection))
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
