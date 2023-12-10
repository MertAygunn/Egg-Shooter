using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [Header("Target")]
    private Transform playerPos;

    [Header("Gameplay")]
    public float speed;
    public int health;
    public GameObject effect;
    public Animator animator;
    public AudioSource deathVoice;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            playerPos.position,
            speed * Time.deltaTime);  

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet") 
        {
            health--;
            if(health <=0)
                {
                Instantiate(effect, transform.position, Quaternion.identity);
                animator.Play("EnemyDeath");
                deathVoice.Play();
                Destroy(gameObject,0.4f);
                }
        }
    }
}