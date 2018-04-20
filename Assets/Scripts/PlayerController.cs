using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
    public GameObject Player;
    private Vector3 force;
    public static Vector2 location;
	// Use this for initialization
	void Start ()
    {
        InitialiseValues();
	}
	// Update is called once per frame
	void Update ()
    {
        Controls();
        ApplyForce();
        WrapUnit();    
	}
    void Controls()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            force.x = force.x-10;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            force.x = force.x + 10;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            force.y = force.y + 10;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            force.y = force.y - 10;
        }      
    }
    void ApplyForce()       //moves the unit
    {
        location = transform.position;
        this.GetComponent<Rigidbody2D>().AddForce(force);
        force = Vector3.zero;
    }
    void InitialiseValues()
    {       
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        force = Vector3.zero;
    }
    void WrapUnit() //x = 43 y = 20 this checks that the player has not dissapeared from screen
    {
        if (transform.position.x > 45 || transform.position.x<-45)
        {
            transform.position = new Vector2(-(location.x), location.y);
        }
        if (transform.position.y > 22 || transform.position.y<-22)
        {
            transform.position = new Vector2(location.x, -(location.y));
        }
    }
    
}

