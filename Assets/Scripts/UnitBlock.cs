using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBlock : MonoBehaviour {

    
    public GameObject cube;
    public int frameCounter = 600;
    public int count = 0;
    int buffer = 0;

	// Use this for initialization
	void Start ()
    {
        frameCounter = Random.Range(50, 1000) + buffer;
        buffer = frameCounter;      
	}	
	// Update is called once per frame
	void Update ()
    {
        TestTime();
	}
    void TestTime()                //timer that removes each block and tells obstacle controller to create a new one
    {
        if (count > frameCounter)
        {
            frameCounter = 0;
            SimManager.NumberBlocks--;
            SimManager.wantedblocks++; 
            Destroy(gameObject);            
        }
        count++;
    }  
}
