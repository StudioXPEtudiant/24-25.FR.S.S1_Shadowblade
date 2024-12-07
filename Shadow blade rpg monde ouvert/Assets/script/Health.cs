using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    public Slider slider;
    
   

    // Start is called before the first frame update
    void Start()
    {
        health = healthmax;
        slider.maxValue = healthmax;
        slider.minValue = healthmin;
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health; 
        if (health <= healthmin )
        {
            objetspnj.SetActive(false);
        }

        if (health <= healthmin)
        {
            health = healthmin;
        }

        if (health >= healthmax)
        {
            health = healthmax;
        }

        if (health <= healthmax)
        {
            health += 1 * Time.deltaTime;
        }
    }

    public void HealthDecrease()
    {
        health += -25f;
    }
}
