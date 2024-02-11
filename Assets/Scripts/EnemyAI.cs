using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 5f; 
    public float stoppingDistance = 2f; 

    private bool isChasing = false; 

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
        Vector2 moveVector = direction * moveSpeed * Time.deltaTime;

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.Translate(moveVector, Space.World);
        }
    }

    public void StartChasingPlayer(Transform targetPlayer)
    {
        player = targetPlayer;
        isChasing = true;
    }
}