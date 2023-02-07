using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideEnemy : EnemyBasic
{
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        speed = 13f;
        spawnLocs.Add(new Vector3(-screenBound - 5, screenBound - 5, 0)); //z always 0
        spawnLocs.Add(new Vector3(0, screenBound - 5, 0));
        spawnLocs.Add(new Vector3(screenBound - 5, screenBound - 5, 0)); //top left/right center
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //after spawn flies towards player
    void Update()
    {

        GameObject targetPlayer = GameObject.FindGameObjectWithTag("Player");
        Vector3 mvDdir = (targetPlayer.transform.position - transform.position).normalized * speed;

        rb.velocity = mvDdir;

    }

    //collision action
}
