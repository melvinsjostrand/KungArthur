using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //patrullerande fiende
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //attackera
    public float timeBetweenAttack;
    bool alreadyAttacked;
    //range
    public float sightRange,attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void awake(){
      player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        //kontrollera sikt och attackräckvidd
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
        playerInAttackRange=  Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) Patroling();//fienden kommer att patrullera om det inte finns någon spelare inom sikte och attackräckvidd
        if(playerInSightRange && !playerInAttackRange) ChasePlayer(); // fienden kommer att jaga spelaren om de är i sikte
        if(playerInAttackRange && playerInAttackRange) AttackPlayer();// fienden kommer att attackera om spelaren är inom sikte och attackräckvidd
    }
    private void Patroling()
    {

    }
    private void ChasePlayer()
    {

    }
    private void AttackPlayer()
    {

    }

}
