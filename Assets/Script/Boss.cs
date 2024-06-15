using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float lineOfSite;
    public float shootingRange;
    public float FireRate = 1f;
    private float nextFireTime;
    public GameObject Bullet;
    public GameObject BulletParent;

    private Transform player;
    private Vector3 initialPosition;    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;        
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < lineOfSite && distanceToPlayer > shootingRange) // Khoảng cách để kích hoạt Boss
            {
                // Di chuyển tới Player
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, movementSpeed * Time.deltaTime);
            }  
            else if (distanceToPlayer <= shootingRange && nextFireTime < Time.time)
            {
                Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + FireRate;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
