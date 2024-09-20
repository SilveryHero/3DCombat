using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{


    Animator animator;
    takingDamage damage;
    Player player;
    public Dash dash;
    public Enemy enemy;
    public bool attack = false;
    public float attackNumber = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        damage = GetComponent<takingDamage>();
    }

    // Update is called once per frame
    void Update()
    {
         //attack
        bool isAttacking = animator.GetBool("Attack");
        bool attackPressed = (Input.GetMouseButtonDown(0));

        if(attackPressed) {
            animator.SetBool("Attack", true);
            attack = true;
            switch (attackNumber) {
                case 0:
                animator.SetBool("Attack3", false);
                animator.SetBool("Attack1", true);
                attackNumber=1;
                break;
            
                case 1:
                animator.SetBool("Attack1", false);
                animator.SetBool("Attack2", true);
                attackNumber=2;
                break;
            
                case 2:
                animator.SetBool("Attack2", false);
                animator.SetBool("Attack3", true);
                attackNumber = 0;
                break;
            }
        }
        if(!attackPressed) {
        animator.SetBool("Attack", false);
        attack = false;
            }


         //walking
         if (player.walking) {
            animator.SetBool("Walking", true);
         } else {
            animator.SetBool("Walking", false);
         }
        if (enemy.dead == true) {
            animator.SetBool("Victory", true);
        }

    }
}