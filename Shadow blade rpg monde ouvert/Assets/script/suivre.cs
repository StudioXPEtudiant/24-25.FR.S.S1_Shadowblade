using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suivre : MonoBehaviour
{
    public Transform joueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = joueur.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
