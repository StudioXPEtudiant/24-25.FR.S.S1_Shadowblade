using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Tir1 : MonoBehaviour
{
    [Header("bool")]
    
    [SerializeField] private bool fixe;

    [SerializeField] private bool tire1;
    
    [Header("laser")]
    
    [SerializeField] private GameObject laser;

    [SerializeField] private Transform laser2;

    [Header("tour")] 
    
    [SerializeField] private Transform tour;

    [Header("wait")] 
    
    [SerializeField] private float wait = 2f;

    [SerializeField] private float wait2 = 1f;

    [Header("player")] 
    
    [SerializeField] private Transform player;
    
    // Start is called before the first frame update

    [SerializeField] private float distance1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laser2.position = tour.position;
        wait += -0.5f * Time.deltaTime;
        if (fixe == false)
        {
            transform.LookAt(player);
        }
        if (wait >= 2)
        {
            wait = 2;
        }

        if (wait >= 0.1)
        {
            fixe = false;
        }
        if (wait <= 0)
        {
            fixe = true;
        }

        if (wait <= -1f)
        {
            wait = 2f;
        }

        if (fixe == false)
        {
            laser.SetActive(false);
            distance1 = Vector3.Distance(player.position, tour.position);
        }

        if (fixe == true)
        {
            TireLaser();
        }
    }

    private void TireLaser()
    {
        tire1 = true;
        laser.SetActive(true);
        laser.transform.localScale = new Vector3(-distance1, 2, distance1);
    }    
}
    
