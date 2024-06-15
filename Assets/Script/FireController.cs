using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject firepoint;
    public GameObject fireprefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {            
            StartCoroutine(DelayFireOn(.5f));
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            StartCoroutine(DelayFireOff(2f)); 
        }
    }
    IEnumerator DelayFireOn(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        anim.SetBool("fire", true);
        Fire();
    }
    private void Fire()
    {
        GameObject newFire = Instantiate(fireprefab, transform.position, Quaternion.identity);
        Rigidbody2D FireRb = newFire.GetComponent<Rigidbody2D>();        
    }
    IEnumerator DelayFireOff(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        anim.SetBool("fire", false);
    }
}
