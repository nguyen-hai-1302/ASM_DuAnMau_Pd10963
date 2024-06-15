using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireshootController : MonoBehaviour
{    
    public float speed;
    Rigidbody2D bulletRB;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();        
        Vector2 moveDir = - transform.position.normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, 0f);
        Destroy(this.gameObject, 2f);
    }

}
