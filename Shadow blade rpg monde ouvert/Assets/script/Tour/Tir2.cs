using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir2 : MonoBehaviour
{
    [SerializeField] private GameObject laser1;
    
    [SerializeField] private LaserActivateTir laser2;

    [SerializeField] private GameObject laserlong;

    [SerializeField] private GameObject tir;

    [SerializeField] private float temps = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void Update()
     {
         Debug.Log("truc");
         temps -= Time.deltaTime;
         if (temps <= 0)
         {
             temps = 1;
             Activate();
         }
     }

    public void Activate()
    {
        GameObject clone = GameObject.Instantiate(tir);
        clone.SetActive(true);
    }
}
