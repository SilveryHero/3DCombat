using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
        
    public Animator animator;
    public Enemy enemy;
    public Transform attackPoint;
    public float attackRange = 2.5f;
    public LayerMask playerLayers;
    public int attackDamage = 40;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
             
        Attack();
        }
        if (enemy.dead == true) {
            this.enabled = false;
        }
    }



    void Attack(){

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayers);

        foreach (Collider player in hitPlayer)
        {
            animator.SetTrigger("Attack");
            player.GetComponent<Player>().TakeDamage(attackDamage);
            nextAttackTime = Time.time +1f / attackRate;
        }

    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}