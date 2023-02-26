using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<EnemyBasic> enemyTypes= new List<EnemyBasic>();
    private int TimeScore;
    private List<Vector3> initlocs= new List<Vector3>();

    private int ybound = 20;
    private int xbound = 15;
    private int ylow = 6;
    void Start()
    {
        enemyTypes.Add(new SuicideEnemy());
        enemyTypes.Add(new LingeringEnemy());
        enemyTypes.Add(new TransitoryEnemy());

        TimeScore = 0;

        for (int i = -xbound; i <= xbound; i++)
        {
            initlocs.Add(new Vector3(i, ybound));
        }

        for (int j = ylow; j <= ybound; j++)
        {
            initlocs.Add(new Vector3(-xbound, j));
            initlocs.Add(new Vector3(xbound, j));
        }

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    IEnumerator SpawnEnemies()
    {

    }


    int SpawnGen()
    {
        return Random.Range(0, 2);
    }
}
