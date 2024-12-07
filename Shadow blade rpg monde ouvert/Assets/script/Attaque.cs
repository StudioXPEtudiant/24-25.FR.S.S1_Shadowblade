using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Attaque : MonoBehaviour
{
    [Header("Metor")]
    public GameObject meteor;
    public Transform meteor2;
    public GameObject terrain;
    
    [Header("AURA")]
    public GameObject aura;

    public float aDD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            meteor.SetActive(true);
            terrain.SetActive(true);
        }

        if (Input.GetKey(KeyCode.F))
        {
            aura.SetActive(true);
            aura.transform.localScale = new Vector3(aDD, aDD, aDD);
        }

        if (Input.GetKey(KeyCode.F))
        {
            aDD += 2 * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            aDD = 0;
            aura.SetActive(false);
        }
    }
    
}
