using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LingeringEnemy : EnemyBasic
{
    // Start is called before the first frame update
    private int rangeYMin = 0;
    private int rangeYMax = 8; //randomized loiter range
    private int rangeXMin = -10;
    private int rangeXMax = 10;
    private List<Vector3> lingerLocs = new List<Vector3>();
    private float updateSpeed;
    private Vector3 destination;
    
    void Start()
    {
        health = 4;
        speed = 5f;
        rb = GetComponent<Rigidbody>();
        //for (int i = rangeYMin; i <= rangeYMax; i++)
        //{
        //    for(int j = rangeXMin; j <= rangeXMax; j++)
        //    {
        //        lingerLocs.Add(new Vector3(j, i, 0));
        //    }
        //}

        float ranx = Random.Range(rangeXMin, rangeXMax);
        float rany = Random.Range(rangeYMin, rangeYMax);

        destination = new Vector3(ranx, rany, 0);
        //destination = new Vector3(1, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeed = Vector3.Distance(transform.position, destination);
        //rb.AddRelativeForce(destination); //drive to destination point slowing down
        //transform.Translate(destination.x * Time.deltaTime, destination.y * Time.deltaTime, 0);
        //rb.MovePosition(destination);
        transform.Translate((destination- transform.position).normalized * (Vector3.Distance(destination, transform.position)) * (Time.deltaTime / 7));
        
    }


    private float GenNewLoc()
    {
        return Random.Range(rangeXMin, rangeXMax);
    }
}
