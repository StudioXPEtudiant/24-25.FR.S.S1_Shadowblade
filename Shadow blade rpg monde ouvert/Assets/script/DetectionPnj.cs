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
        if (Vector3.Distance(Pnj.position, transform.position) < detection)
        {
            activerClick = true;
        }

        if (Vector3.Distance(Pnj.position, transform.position) > detection)
        {
            activerClick = false;
        }

        if (activerClick = true)
        {
            Debug.Log("true");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Appuiyer");
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detection);
    }
}
