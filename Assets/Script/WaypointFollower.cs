﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{    
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private int currentWaypointIndex = 0;
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
   
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {            
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) > .1f)
            {
                 currentWaypointIndex = 0;
            }            
        }
    }
}
