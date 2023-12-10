using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    bool facingRight = true;

    [Header("Game Play")]
    float inputHorizontal;
    float inputVertical;
    public float speed;
    private Vector2 movement;
    public int health;
    public int maxHealth = 10;
    

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    public HealthBar healthBar;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
            Destroy(gameObject);


        }
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2
           (movement.x * speed,
            movement.y * speed);

        if (inputHorizontal !=0)
        {
            rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
        }
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
        dashAnim();
        if (Input.GetKeyDown(KeyCode.LeftShift) & canDash)
        {
            StartCoroutine(Dash());
        }

        runAnim();
        if (Input.GetKeyDown(KeyCode.LeftShift) & canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void runAnim() {
        if(movement.x != 0 || movement.y != 0) {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }
    }
    private void dashAnim()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) & canDash)
        {
            animator.SetBool("isDashing", true);
        }
        else
        {
            animator.SetBool("isDashing", false);
        }
    }

    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        facingRight = !facingRight;
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
