using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser2 : MonoBehaviour
{

    [SerializeField] private Transform tour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tour.position;
        transform.eulerAngles = tour.eulerAngles;
    }
}
