using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerLifeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource deathSource;
    public Slider slider;
    Vector2 checkPointPos;
    //public float sliderHeal;
    // Start is called before the first frame update
    private void Start()
    {
        slider.value = 5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checkPointPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            slider.value--;
            transform.position = checkPointPos;
            if (slider.value == 0)
            {
                Die();
            }            
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            slider.value--;
            transform.position = checkPointPos;
            if (slider.value == 0)
            {
                Die();
            }
        }
    }
    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }
    private void Die()
    {
        deathSource.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
