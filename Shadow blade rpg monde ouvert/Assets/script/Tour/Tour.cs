using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Tour : MonoBehaviour
{
    
    [SerializeField] private bool isTurn = true;

    [SerializeField] private float turn;
    
    [Header("Distance Tire")]
    
    [SerializeField] private float distanceTir1;
    
    [SerializeField] private float distanceTir2;
    
    [SerializeField] private float distanceTir3;
    
    [Header("speed")]
    
    [SerializeField] private float speedRotationStable;
    
    [SerializeField] private float speedRotationMin;
    
    [SerializeField] private float speedRotationMax;

    [Header("Player")] 

    [SerializeField] private Transform player2;

    [Header("Bool")]
    
    [SerializeField] private bool tir1;
    
    [SerializeField] private bool tir2;
    
    [SerializeField] private bool tir3;

    [Header("script")] 
    
    [SerializeField] private Tir1 tiR1;
    
    [SerializeField] private Tir2 tiR2;
    
    [SerializeField] private Tir3 tiR3;

    [Header("laser")] 
    
    [SerializeField] private GameObject laserLong;
    
    [SerializeField] private GameObject sword;
    
    [SerializeField] private GameObject tir;

    [Header("float")]
    [SerializeField] private float wait = 2f;
    // Start is called before the first frame update
    void Start()
    {
        speedRotationStable = speedRotationMax;
        isTurn = false;
        tiR1.enabled = false;
        tiR2.enabled = false;
        tiR3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player2.position, transform.position)< distanceTir1)
        {
            isTurn = false;
            tiR1.enabled = true;
            tiR2.enabled = false;
            tiR3.enabled = false;
            tiR3.UnActive();
        } 
        if (Vector3.Distance(player2.position, transform.position)< distanceTir2)
        {
            isTurn = false;
            tiR1.enabled = false;
            tiR2.enabled = true;
            transform.LookAt(player2);
            tiR3.enabled = false;
            tiR3.UnActive();
        } 
        if (Vector3.Distance(player2.position, transform.position)< distanceTir3)
        {
            laserLong.SetActive(false);
            tiR1.enabled = false;
            tiR2.enabled = false;
            tiR3.enabled = true;
            tiR3.Activate();
        } 
        if (Vector3.Distance(player2.position, transform.position)> distanceTir1)
        {
            laserLong.SetActive(false);
            tir.SetActive(false);
            sword.SetActive(false);
            isTurn = true;
            tiR1.enabled = false;
            tiR2.enabled = false;
            tiR3.enabled = false;
            tiR3.UnActive();
        }
      
        if(isTurn == true)
        {
            if (turn <= 0)
            {
                turn = 0;
                speedRotationStable = speedRotationMax;
            }

            if (turn >= 360)
            {
                turn = 360;
                speedRotationStable = speedRotationMin;
            }
            turn += speedRotationStable * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, turn, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceTir1);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceTir2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceTir3);
    }
}