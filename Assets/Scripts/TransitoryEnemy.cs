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
    private int attType;
    Vector3 forceDir;

    private float minwt = 0.5f;
    private float maxwt = 1.5f;

    private float radius = 5f;
    private Vector3 initLoc;
    public GameObject bullet;

    private eAttackController attackController = new eAttackController();

    //private eAttackController attacker;


    void Start()
    {
        health = 2;
        speed = 10f;
        attType = 0;
        initLoc = transform.position;
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


        //StartCoroutine(teRadial());
        //StartCoroutine(teTendril());
        StartCoroutine(trAttack());

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 forceDir = new Vector3(-transform.position.x, transform.position.y + deltaY);
        rb.velocity = forceDir.normalized;
        initLoc = transform.position;

    }


    //lingering enemy uses radial and rotate
    //transient enemy rapid fires homing attack
    //both done in coroutines
    //lingering willuse periodic radial every 2-3 seconds
    //rotate script varied 4-6 seconds at 15-25 tendrils every 10 seconds

    public void HomingAttack()
    {
        //float xDir;
        //float yDir;
        float speed = 10f;

        GameObject target = GameObject.FindGameObjectWithTag("Player");

        Vector3 mvDir = (target.transform.position - transform.position).normalized * speed;
        var hAtt = Instantiate(bullet, initLoc, Quaternion.identity);
        hAtt.GetComponent<Rigidbody>().velocity = new Vector3(mvDir.x, mvDir.y, mvDir.z);


    }


    IEnumerator trAttack()
    {
        while(true)
        {


            HomingAttack();
            float randWait = Random.Range(minwt, maxwt);
            yield return new WaitForSeconds(randWait);


        }





    }




}
