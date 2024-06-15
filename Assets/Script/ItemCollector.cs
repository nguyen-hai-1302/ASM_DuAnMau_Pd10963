using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;
    public AudioSource collectionSource;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Cherry"))
        {
            collectionSource.Play();
            Destroy(coll.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Cherry"))
        {
            collectionSource.Play();
            Destroy(coll.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
