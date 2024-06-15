using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAtt : MonoBehaviour
{
    public float shootingRange;
    public float FireRate = 1f;
    private float nextFireTime;
    public GameObject Bullet;
    public GameObject BulletParent;
    private Animator anim;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= shootingRange && nextFireTime < Time.time)
            {
                anim.SetBool("Attack", true);
                Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + FireRate;
            }
        }
        anim.SetBool("Attack", false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;        
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
