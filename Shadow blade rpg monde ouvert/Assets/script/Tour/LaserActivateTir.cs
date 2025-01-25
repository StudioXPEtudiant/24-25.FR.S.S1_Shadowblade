using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserActivateTir : MonoBehaviour
{
    [SerializeField] private Transform tour;

    [SerializeField] private Transform player;

    [SerializeField] private GameObject laser;

    [SerializeField] private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = tour.position;
        transform.eulerAngles = tour.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 1;
    }
    
}