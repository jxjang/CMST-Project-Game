using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TransitoryEnemy : EnemyBasic
{
    // Start is called before the first frame update

    //spawn offscreen, moves relatively quickly offscreen
    //private float xMin , xMax;
    //private float yMin , yMax;
    private float yWanderRange = 3f;
    private float deltaY;
    private float varSpeed;
    private float minspeed = 5f;
    private float maxspeed = 15f;
    Vector3 forceDir;
    void Start()
    {
        health = 2;
        speed = 10f;
        //spawnLocs
        //for (int i = 0; i < 10; i++)
        //{
        //two rows of spawn locations top half sides
        //}
        deltaY = Random.Range(-yWanderRange, yWanderRange);
        rb = GetComponent<Rigidbody>();
        varSpeed = Random.Range(minspeed, maxspeed);
        forceDir = new Vector3(-transform.position.x, transform.position.y + deltaY);
        //forceDir = new Vector3(-transform.position.x, transform.position.y + deltaY, 0);
        //rb.velocity = forceDir.normalized * Time.deltaTime *5;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 forceDir = new Vector3(-transform.position.x, transform.position.y + deltaY);
        rb.velocity = forceDir.normalized;
        
    }
}
