using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    private Vector2 target; 
    public float speed;
    public float lifetime;
    public PlayerHealth playerHealth;

    void Start() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    {  
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
        
        Destroy(gameObject, lifetime);
    }
}
