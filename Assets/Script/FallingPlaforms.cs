using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlaforms : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("on", true);
            StartCoroutine(DelayFPOn(3f));
            StartCoroutine(DelayFPDown(2f));
            Destroy(gameObject, 6f);
        }
    }    
    IEnumerator DelayFPOn(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
    }
    IEnumerator DelayFPDown(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        rb.velocity = new Vector2(rb.velocity.x, -14f);
    }
}
