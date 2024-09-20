using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takingDamage : MonoBehaviour
{
    // Start is called before the first frame update
       AnimationController animation;
       public float hitCooldown;
       public bool hit = false;

    void Start()
    {
        animation = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {

            if (this.tag == "Living" && animation.attack) {
            //GameObject hitted = other.gameObject;
            if (hit == false){
            hit = true;
            hitCooldown = 1 ;
            }
        }
        if (hitCooldown > 0) {
            hitCooldown -= Time.time;
        }
        if (hitCooldown <= 0) {
            hit = false;
        }
    }

        private void OnTriggerEnter (Collider other){


    
    }
}
