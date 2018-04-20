using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimManager : MonoBehaviour
{

    public int NumberUnit;                              //Amount of units to create
    public GameObject[] UnitsBlue;                      //Array that holds the units
    public GameObject unitPrefabB;                      //UnitBlue prefab
    public GameObject[] UnitsRed;                       //array to hold red units
    public GameObject UnitPrefabR;                      //Red Prefab
    public GameObject[] UnitsGreen;                     //Array to hold Green units
    public GameObject UnitPrefabG;                      //Green Prefab
    public Vector2 spawnDistance = new Vector2(20, 20); //default spawn distance
    public float neighbourLimit = 1;                    //default neighbour limit
    public Vector2 goal = new Vector2(0, 0);            //default goal location
    public GameObject[] Blocks;
    public GameObject UnitPrefabBlock;
    public static int NumberBlocks;                     //amount of obstacles initialised
    public static int wantedblocks;                     //blocks that the user wants to create
    public GameObject Obstacle;                         //Obstacle prefab
    public Stack Squares;                               //Stack to hold the Obstacles
    public GameObject manager;
    public GameObject player;
    private void Awake()
    {
        //CheckNumbers();
        //CheckCreation();
        Squares = new Stack();
    }
    // Use this for initialization
    void Start()
    {
        CheckNumbers();
        CheckCreation();
    }
    // Update is called once per frame

    public void CheckCreation()         //checks which boolean values the user wants
    {

        bool bluetrue = Settings.blue;
        bool greentrue = Settings.green;
        bool redtrue = Settings.red;
        if (bluetrue == false)
        {
            CreateBlueUnits();
            Debug.Log("created blue");
        }
        else
        {
            Destroy(unitPrefabB);
        }
        if (greentrue == false)
        {
            CreateGreenUnits();
        }
        else
        {
            Destroy(UnitPrefabG);
        }
        if (redtrue == false)
        {
            CreateRedUnits();
        }
        else
        {
            Destroy(UnitPrefabR);
        }
        if (Settings.player == true)
        {
            Destroy(player);
        }
    }
    public void CheckNumbers()          //assigns the integer settings from the menu scene
    {
        NumberUnit = Settings.intFlockMembers;
        wantedblocks = Settings.intamountObstacles;
    }
    /// <summary>
    /// next three methods create the units for each of the desired colour groups
    /// </summary>
    public void CreateBlueUnits()
    {
        UnitsBlue = new GameObject[NumberUnit];
        for (int count = 0; count < NumberUnit - 1; count++)
        {
            Vector3 FishPosition = new Vector2(Random.Range(spawnDistance.x, spawnDistance.y), Random.Range(spawnDistance.x, spawnDistance.y)); UnitsBlue[count] =
                  Instantiate(unitPrefabB, this.transform.position + FishPosition, Quaternion.identity);
            //Vector3 FishPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)); UnitsBlue[count] =
            //       Instantiate(unitPrefab, this.transform.position + FishPosition, Quaternion.identity);
            UnitsBlue[count].GetComponent<UnitBlue>().manager = this.gameObject;
        }
    }
    void CreateRedUnits()
    {
        UnitsRed = new GameObject[NumberUnit];
        for (int count = 0; count < NumberUnit - 1; count++)
        {
            Vector3 FishPosition = new Vector2(Random.Range(spawnDistance.x + 10, spawnDistance.y + 10), Random.Range(spawnDistance.x, spawnDistance.y)); UnitsRed[count] =
                      Instantiate(UnitPrefabR, this.transform.position + FishPosition, Quaternion.identity);
            UnitsRed[count].GetComponent<UnitRed>().manager = this.gameObject;
        }
    }
    void CreateGreenUnits()
    {
        UnitsGreen = new GameObject[NumberUnit];
        for (int count = 0; count < NumberUnit - 1; count++)
        {
            Vector3 FishPosition = new Vector2(Random.Range(spawnDistance.x - 10, spawnDistance.y - 10), Random.Range(spawnDistance.x, spawnDistance.y)); UnitsGreen[count] =
                      Instantiate(UnitPrefabG, this.transform.position + FishPosition, Quaternion.identity);
            UnitsGreen[count].GetComponent<UnitGreen>().manager = this.gameObject;
        }
    }
}

   
    //public void CreateObstacles()
    //{
        //    int Totalspawned = 0;
        //    Blocks = new GameObject[NumberBlocks];
        //    for (arraypointer = 0; arraypointer < wantedblocks; arraypointer++)
        //    {

        //        Vector3 BlockPosition = new Vector2(Random.Range(spawnDistance.x, spawnDistance.y),
      //            Random.Range(spawnDistance.x, spawnDistance.y));
    //        Blocks[arraypointer] = Instantiate(hazardprefab, this.transform.position + BlockPosition, Quaternion.identity);

    //        Blocks[arraypointer].GetComponent<UnitBlock>().manager = this.gameObject;
    //        Totalspawned++;

        //for (int k = Squares.Count; k<wantedblocks; k++)
        //{
        //    int randx = Random.Range(-30, 30);
        //    int randy = Random.Range(-20, 20); 

        //    Squares.Push((GameObject)Instantiate(Obstacle, new Vector3(randx,randy 
        //        , Obstacle.transform.position.z), Obstacle.transform.rotation));
           
        //    Obstacle.AddComponent<UnitBlock>();
        //    NumberBlocks++;
        
        //wantedblocks = 0;

//    void TestObstacles()
//    {
//        int testNumber = 4;
//        int compare = Random.Range(1, 100);

//        if (testNumber == compare)
//        {
//            if (wantedblocks > 0)
//            {
//                CreateObstacles();
//            }
//            if (wantedblocks < 0)
//            {
//                wantedblocks = 0;
//            }

//            if (NumberBlocks < 0)
//            {
//                NumberBlocks = 0;
//            }
//        }   
//    }

    

//}


   