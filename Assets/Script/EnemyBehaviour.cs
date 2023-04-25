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
    public GameObject projectilePrefab;
    public float projectileSpeed;
    //range
    public float sightRange,attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void Awake(){
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
        if(!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
           agent.SetDestination(walkPoint);
        Vector3 DistanceToWalkPoint = transform.position- walkPoint;
        if(DistanceToWalkPoint.magnitude<1f)
        walkPointSet=false;
    }
    private void SearchWalkPoint()
    {  //hitta en slumpmässig walk point
      float randomZ = Random.Range(-walkPointRange,walkPointRange);
      float randomX = Random.Range(-walkPointRange,walkPointRange);
      walkPoint = new Vector3(transform.position.x+ randomX, transform.position.z + randomZ);
       // kontrollera om walk point är på marken
      if (Physics.Raycast(walkPoint,-transform.up,2f,whatIsGround))
           walkPointSet=true;
    }
    private void ChasePlayer()
    {
      agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
      agent.SetDestination(transform.position);
      transform.LookAt(player);
      if(!alreadyAttacked)
      { 
    GameObject projectileObject = Instantiate(projectilePrefab, transform.position + transform.forward, Quaternion.identity);
    Projectile projectile = projectileObject.GetComponent<Projectile>();
    projectile.Launch(player.position - transform.position, projectileSpeed);
        
        alreadyAttacked = true;
        Invoke(nameof(ResetAttack),timeBetweenAttack);
      }
    }
    private void ResetAttack()
    {
      alreadyAttacked=false;
    }

}
