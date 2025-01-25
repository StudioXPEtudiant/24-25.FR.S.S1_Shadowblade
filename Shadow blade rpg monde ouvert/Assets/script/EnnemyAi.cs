using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnnemyAi : MonoBehaviour
{
    [Header("animator")] [SerializeField] private Animator _animator;
    
    [Header("AttaqueJoueur")]
    public Health _healt;

    public float timeAttack = 1f;
    [SerializeField] private float detectionAttack;
    
    public bool attaque;
    [Header("References")] [SerializeField]
    private Transform player;

    [SerializeField] private NavMeshAgent agent;

    [Header("stats")] [SerializeField] private float detectionRadius;
    

    private bool hasDestination;

    [Header("parameter")]
    [SerializeField] 
    private float wanderingWaitTimeMin;

    [SerializeField]
    private float wanderingWaitTimeMax;

    [SerializeField] private float wanderingDistanceMin;
    [SerializeField] private float wanderingDistanceMax;
    
    
    public GameObject player1;
    
    // Start is called before the first frame update
    void Start()
    {
        _healt = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < detectionRadius)
        {
            agent.SetDestination(player.position);
            

            if (!attaque)
            {
                if (Vector3.Distance(player.position, transform.position) < detectionAttack)
                {
                    StartCoroutine(attaquejoueur());
                    Debug.Log("attaquer");
                }
                else
                {
                    agent.SetDestination(player.position);
                }
            }
        }
        else
        {
            if (agent.remainingDistance < 0.75f && !hasDestination)
            {
                StartCoroutine(GetNewDestination());
            } 
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("AURA"))
            {
                Debug.Log("Collision détectée avec : " + CompareTag("AURA"));
            }
        }

        
         void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("AURA"))
            {
                Debug.Log("Fin de collision avec : ");
            }
        }
    }

    IEnumerator GetNewDestination()
    {
        hasDestination = true;
        yield return new WaitForSeconds(Random.Range(wanderingWaitTimeMin, wanderingWaitTimeMax));

        Vector3 nextDestination = transform.position;
        nextDestination += Random.Range(wanderingDistanceMin, wanderingDistanceMax)* new Vector3(Random.Range(-1f, 1), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, wanderingDistanceMax, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            hasDestination = false;
        }
    }
        

    IEnumerator attaquejoueur()
    {
        attaque = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(timeAttack);
        agent.isStopped = false;
        attaque = false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionAttack);
    }
    
}