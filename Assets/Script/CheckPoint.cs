using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator anim;
    PlayerLifeController gameController;
    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeController>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Notice", true);
            gameController.UpdateCheckPoint(transform.position);
        }
    }
}
