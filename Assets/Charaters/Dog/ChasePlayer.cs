using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //patroling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (playerInSightRange && !playerInAttackRange) ChasePlayerMethod();
        if (playerInSightRange && !playerInAttackRange) AttackPlayer();
    }// end update


    private void ChasePlayerMethod()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //make suer enemy doesnt move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack code here

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    
    private void ResetAttack()
    {
        alreadyAttacked= false;
    }

    public void OnConnectedToServer(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);

    }

    private void DestroyEnemy()
    {
        
    }
}
