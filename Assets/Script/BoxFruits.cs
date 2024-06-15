using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxFruits : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject[] fruits;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;    
    // Start is called before the first frame update

    private void Start()
    {        
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("hitbox", true);
            StartCoroutine(FruitSpawn());            
            Destroy(gameObject,1f);
        }
    }

    IEnumerator FruitSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(fruits[Random.Range(0, fruits.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
        }        
    }
}
