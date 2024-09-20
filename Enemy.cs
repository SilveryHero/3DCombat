using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool dead;

    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage){
        currentHealth -= damage;
        animator.SetTrigger("Hit");
        //animation
        if (currentHealth <=0){
            Die();
        }
    }

    void Die() {
        Debug.Log("Enemy died!");
        dead = true;
        animator.SetBool("Dead", true);
        GetComponent<Collider>().enabled = false;
        this.enabled = false;

    }


}
