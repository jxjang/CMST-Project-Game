using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eAttackController : MonoBehaviour
{
    // Start is called before the first frame update
    //private float bSpeed;
    //class for holding methods 
    //each method is different type of attack simplified
    //enemy class will specify details of attacks
    private float radius = 5f;

    public void RadialAttack(Vector3 initLoc, GameObject bullet, int numProjectiles)
    {
        float stepAngle = 360f / numProjectiles;
        float initAngle = 0f;

        for ( int i = 0; i <= numProjectiles; i++ )
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

    public void RotateRadialAttack(Vector3 initLoc, GameObject bullet, int numProjectiles, int shots)
    {
        StartCoroutine(rotateEx(initLoc, bullet, numProjectiles, shots));
    }
    

    IEnumerator rotateEx(Vector3 initLoc, GameObject bullet, int numProjectiles, int numShots)
    {

        float stepAngle = 360f / numProjectiles;
        float initAngle = 0f;

        for (int j = 0; j < numShots;j++ )
        {
            for (int i = 0; i < numProjectiles-1; i++)
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
            yield return new WaitForSeconds(0.1f);
        }

        



        //yield return new WaitForSecondsRealtime(0.1f);
    }

    public void HomingAttack(Vector3 initLoc, GameObject bullet)
    {
        //float xDir;
        //float yDir;
        float speed = 10f;

        GameObject target = GameObject.FindGameObjectWithTag("Player");

        Vector3 mvDir = (target.transform.position - transform.position).normalized * speed;
        var hAtt = Instantiate(bullet, initLoc, Quaternion.identity);
        hAtt.GetComponent<Rigidbody>().velocity = new Vector3(mvDir.x, mvDir.y, mvDir.z);


    }

    //lingering enemy uses radial and rotate
    //transient enemy rapid fires homing attack
    //both done in coroutines
    //lingering willuse periodic radial every 2-3 seconds
    //rotate script varied 4-6 seconds at 15-25 tendrils every 10 seconds






 }







