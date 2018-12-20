using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

    //Members 
    
    public float health = 1.0f;
    public float pointsGiven = 1.0f;
    public float moveSpeed = 2.0f;
    private Vector3 initial;
    private float passedTime = 0.0f;
    private GameObject player;
    public NavMeshAgent agent;
    private float alive = 1.0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        initial = transform.position;
        
    }
    // Update is called once per frame
    void Update () {

        agent.SetDestination(player.transform.position);


        if (health <= 0)
        {
            DieRespawn();
        }

    }
    public void DieRespawn()
    {
        //print("Enemy dies " + this.gameObject.name);
        player.GetComponent<Player>().points += pointsGiven;
        transform.position = initial;
        health += 1;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }


}
