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
    //private List<Vector3> lingerLocs = new List<Vector3>();
    private float updateSpeed;
    private Vector3 destination;



    private float radialRate = 2f;
    private float radialDealta = 1f;
    private int minProj = 5;
    private int maxProj = 10;

    private float rotateRate = 8f;
    private float rotateDelta = 3f;
    //private float rotateDuration = 4f;

    private int minAttsRot = 10;
    private int maxAttsRot = 15;

    private eAttackController attackController = new eAttackController();




    private float radius = 5f;
    private Vector3 initLoc;
    public GameObject bullet;

    void Start()
    {
        speed = 5f;
        rb = GetComponent<Rigidbody>();
        initLoc = transform.position;
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

        StartCoroutine(teRadial());
        StartCoroutine(teTendril());

    }

    // Update is called once per frame
    void Update()
    {
        initLoc = transform.position;
        updateSpeed = Vector3.Distance(transform.position, destination);
        //rb.AddRelativeForce(destination); //drive to destination point slowing down
        //transform.Translate(destination.x * Time.deltaTime, destination.y * Time.deltaTime, 0);
        //rb.MovePosition(destination);
        transform.Translate((destination- transform.position).normalized * (Vector3.Distance(destination, transform.position)) * (Time.deltaTime / 7));
        OutOfBounds();
    }


    //private float GenNewLoc()
    //{
    //    return Random.Range(rangeXMin, rangeXMax);
    //}






    //lingering enemy uses radial and rotate
    //transient enemy rapid fires homing attack
    //both done in coroutines
    //lingering willuse periodic radial every 2-3 seconds
    //rotate script varied 4-6 seconds at 15-25 tendrils every 10 seconds


    IEnumerator teRadial()
    {
        float waitDur = Random.Range(radialRate - (radialDealta / 2), radialRate + (radialDealta / 2));

        int radProj = Random.Range(minProj, maxProj);

        RadialAttack(initLoc, bullet, radProj);

        yield return new WaitForSeconds(waitDur);
    }


    IEnumerator teTendril()
    {

        while(true)
        {
            float waitDur = Random.Range(rotateRate - (rotateDelta / 2), rotateRate + (rotateDelta / 2));
            int radProj = Random.Range(minProj, maxProj);
            int numattsRot = Random.Range(minAttsRot, maxAttsRot);

            RotateRadialAttack(radProj, numattsRot);

            yield return new WaitForSeconds(waitDur);
        }


        

    }

    public void RadialAttack(Vector3 initLoc, GameObject bullet, int numProjectiles)
    {
        float stepAngle = 360f / numProjectiles;
        float initAngle = 0f;

        for (int i = 0; i <= numProjectiles; i++)
        {
            float xDir = initLoc.x + Mathf.Sin((initAngle * Mathf.PI) / 180) * radius;
            float yDir = initLoc.y + Mathf.Cos((initAngle * Mathf.PI) / 180) * radius;

            Vector3 tempVector = new Vector3(xDir, yDir, 0);
            Vector3 vectorDirection = (tempVector - initLoc).normalized * 10;

            var proj = Instantiate(bullet, initLoc, Quaternion.identity);
            proj.GetComponent<Rigidbody>().velocity = new Vector3(vectorDirection.x, vectorDirection.y, vectorDirection.z);
            initAngle += stepAngle;
        }
    }

    public void RotateRadialAttack(int numProjectiles, int shots)
    {
        StartCoroutine(rotateEx(numProjectiles, shots));

    }


    IEnumerator rotateEx(int numProjectiles, int numShots)
    {

        float stepAngle = 360f / numProjectiles;
        float initAngle = 0f;

        for (int j = 0; j < numShots; j++)
        {
            for (int i = 0; i < numProjectiles - 1; i++)
            {
                float xDir = initLoc.x + Mathf.Sin((initAngle * Mathf.PI) / 180) * radius;
                float yDir = initLoc.y + Mathf.Cos((initAngle * Mathf.PI) / 180) * radius;

                Vector3 tempVector = new Vector3(xDir, yDir, 0);
                Vector3 vectorDirection = (tempVector - initLoc).normalized * 10;

                var proj = Instantiate(bullet, initLoc, Quaternion.identity);
                proj.GetComponent<Rigidbody>().velocity = new Vector3(vectorDirection.x, vectorDirection.y, vectorDirection.z);
                initAngle += stepAngle;
                initAngle += 10;

                //yield return new WaitForSeconds(0.15f);
                
            }
            if (initAngle >= 360)
            {
                initAngle -= 360;
            }
            yield return new WaitForSeconds(0.2f);
        }





        //yield return new WaitForSecondsRealtime(0.1f);
    }




}
