using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    List<GameObject> columns = new List<GameObject>();      //list to hold obstacle gameobjects
    int xlimits = 43;                                        //the limits to create objects within
    int ylimits = 20;
    public static int columnslength;
    public GameObject col;

    void Start()
    {       
        InvokeRepeating("ClearFirstColumn", 2,10);          
        Creation();
    }
    void Update()
    {
        
    }
    void Creation()     //creates the initial obstacles
    {
        for (int i = 0; i < Settings.intamountObstacles; i++)
        {

            Vector3 x = new Vector3(UnityEngine.Random.Range(-xlimits, xlimits), UnityEngine.Random.Range(-ylimits, ylimits), 0);
            //x = new Vector3(offset,0,0 );        
            columns.Add(Instantiate(col, x, Quaternion.identity));
        }
    }
    void ClearFirstColumn()     //removes the obstacle at the start of the list and then adds another in a different location
    {
        Vector3 x = new Vector3(UnityEngine.Random.Range(-xlimits, xlimits), UnityEngine.Random.Range(-ylimits, ylimits), 0);
        DestroyObject(columns[0]);
        columns.RemoveAt(0);
        columns.Add(Instantiate(col, x, Quaternion.identity));
        columnslength = columns.Count;
    }
}
