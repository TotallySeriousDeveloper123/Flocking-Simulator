using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRed : MonoBehaviour
{

    public GameObject manager;
    public Vector2 location = Vector2.zero;     //initialises location, velocity, units goal and the force
    public Vector2 velocity = Vector2.zero;
    public int RandomLimiter = 10;
    Vector2 Unitgoal = Vector2.zero;
    Vector2 Force = Vector2.zero;



    // Use this for initialization
    void Start()
    {
        startSetting();
        

    }

    // Update is called once per frame
    void Update()
    {
        flock();

    }
    void startSetting()
    {
        Push(new Vector2(Random.Range(-RandomLimiter, -RandomLimiter), (Random.Range(-RandomLimiter, RandomLimiter))));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        CreategoalLocation();
    }
    //moves the unit
    void Push(Vector2 speed)
    {
        Vector3 force = new Vector3(speed.x, speed.y, 0);
        this.GetComponent<Rigidbody2D>().AddForce(force);

    }
    //returns distance to target
    Vector2 Seek(Vector2 Target)
    {
        return (Target - location);
    }

    //works out the orientation of the unit
    Vector2 alignment()
    {
        float neighbourLimit = manager.GetComponent<SimManager>().neighbourLimit;
        Vector2 sum = new Vector2(0, 0);
        Vector2 steer = new Vector2(0, 0);
        float count = 0;
        foreach (GameObject other in manager.GetComponent<SimManager>().UnitsRed)
        {
            if (other == this.gameObject) continue;
            {
                float distance = Vector2.Distance(location, other.GetComponent<UnitRed>().location);
                if (distance < neighbourLimit)
                {
                    sum = sum + other.GetComponent<UnitRed>().velocity;
                    count++;
                }
            }
            if (count > 0)
            {
                sum = sum / count;
                steer = sum - velocity;
                return steer;
            }
        }
        return Vector2.zero;
    }
    //works out the velocity of the unit
    Vector2 cohesion()
    {
        float neighbourDistance = manager.GetComponent<SimManager>().neighbourLimit;
        Vector2 sum = new Vector2(0, 0);
        float count = 0;

        foreach (GameObject other in manager.GetComponent<SimManager>().UnitsRed)
        {
            if (other == this.gameObject) continue;
            {
                float distance = Vector2.Distance(location, other.GetComponent<UnitRed>().location);
                if (distance < neighbourDistance)
                {
                    sum = sum + other.GetComponent<UnitRed>().location;
                    count++;
                }
            }
            if (count > 0)
            {
                sum = sum / count;
                return Seek(sum);
            }
        }
        return Vector2.zero;

    }
    //combines cohesion and alignment
    void flock()
    {
        location = transform.position;
        velocity = this.GetComponent<Rigidbody2D>().velocity;
        if (Random.Range(0, 1) < 1)
        {
            Vector2 orientation = alignment();
            Vector2 proximity = cohesion();
            Unitgoal = Seek(Unitgoal);
            Force = orientation + proximity; //+ 0.5f*Unitgoal;
            Force = Force.normalized;
            WrapUnit();
        }

        Push(Force);

    }

    void CreategoalLocation()
    {
        Unitgoal = PlayerController.location;
    }

    void WrapUnit() //x = 43 y = 20
    {
        if (transform.position.x > 45 || transform.position.x < -45)
        {
            transform.position = new Vector2(-(location.x), location.y);
        }
        if (transform.position.y > 22 || transform.position.y < -22)
        {
            transform.position = new Vector2(location.x, -(location.y));
        }
    }
}