using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir3 : MonoBehaviour
{
    [Header("Objet")]
    [SerializeField] private Transform player;
    
    [SerializeField] private GameObject laser;
    
    [SerializeField] private Transform laser2;
    
    [SerializeField] private Transform tour;

    [SerializeField] private float rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Activate()
    {
        laser.SetActive(true);
        rotation += 720f * Time.deltaTime;
        if (rotation >= 100000)
        {
            rotation = 0;
        }
        transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }

    public void UnActive()
    {
        laser.SetActive(false);
    }
}
