using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petrol_Man_AI : MonoBehaviour
{
    public float enemySpeed = 10f;
    public GameObject petrol;
    public LayerMask townHallLayer;

    private Vector2 point;
    private Rigidbody2D rb;
    private Animator animator;
    private Town_Hall_Health_System townHallHealthSystem;
         
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        townHallHealthSystem = GameObject.FindGameObjectWithTag("Town Hall").GetComponent<Town_Hall_Health_System>();
    }

    private void Update()
    {
        point = new Vector2(transform.position.x + transform.localScale.x, transform.position.y);
        if (Physics2D.OverlapCircle(point, 5f, townHallLayer))
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("attack", true);
        }
        else
            rb.velocity = new Vector2(transform.localScale.x * enemySpeed, rb.velocity.y);
    }

    private void ThrowProjectile()
    {
        GameObject petrolBin = Instantiate(petrol, transform.position + new Vector3(0.5f * transform.localScale.x, 0, 0), Quaternion.identity);
        petrolBin.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f * transform.localScale.x, 400f));
    }
}
