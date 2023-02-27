using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuicideEnemy : EnemyBasic
{
    // Start is called before the first frame update

    GameObject targetPlayer;
    Vector3 mvDir;
    float adjustForce = .03f;
    void Start()
    {
        speed = 13f;
        spawnLocs.Add(new Vector3(-screenBound - 5, screenBound - 5, 0)); //z always 0
        spawnLocs.Add(new Vector3(0, screenBound - 5, 0));
        spawnLocs.Add(new Vector3(screenBound - 5, screenBound - 5, 0)); //top left/right center
        rb = GetComponent<Rigidbody>();

        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        if (targetPlayer)
        {
            mvDir = (targetPlayer.transform.position - transform.position).normalized * speed;

            rb.velocity = mvDir;
        }
    }

    // Update is called once per frame
    //after spawn flies towards player
    void Update()
    {
        if (targetPlayer && (transform.position.y > targetPlayer.transform.position.y))
        {
            Vector3 adjPos = targetPlayer.transform.position;
            rb.AddForce(adjPos);
        }
        OutOfBounds();
    }
}
