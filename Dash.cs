using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Player player;
    public float dashSpeed = 15f;
    public float dashRate = 0.5f; 
    void Start()
    {
        player = GetComponent <Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            StartCoroutine(Dashing());
    }
}

    IEnumerator Dashing() {
        float startTime = Time.time;
        while (Time.time < startTime + dashRate){
            player.controller.Move(player.moveDirect *dashSpeed * Time.deltaTime);
            yield return null;
        }

    }
}
