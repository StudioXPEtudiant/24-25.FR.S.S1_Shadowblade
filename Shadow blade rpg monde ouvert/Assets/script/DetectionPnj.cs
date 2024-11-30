using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPnj : MonoBehaviour
{
    public float detection = 2f;

    public Transform Pnj;

    public bool activerClick;

    private Dialogue _dialogue;
    // Start is called before the first frame update
    void Start()
    {
        _dialogue = GetComponent<Dialogue>();
        activerClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKey(KeyCode.H))
        {   
            Debug.DrawRay(transform.position, transform.forward * detection, Color.red);
        }
    }
}
