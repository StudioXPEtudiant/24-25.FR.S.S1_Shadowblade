using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Variable de vie")]
    
    public float healthmax;

    public float healthmin;
    
    public float health;

    [Header("dégats")]
    
    public float degat;
    
    public float resistance;
    
    [Header("objets")]
    
    public GameObject objetspnj;

    public RectTransform image;

    public GameObject image2;


    // Start is called before the first frame update
    void Start()
    {
        health = healthmax;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= healthmin )
        {
            
        }
    }
}
