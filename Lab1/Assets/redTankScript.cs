using System.Collections;
using System.Collections.Generic;
using static System.Math;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class redTankScript : MonoBehaviour
{
    public float radius;
    public int numWaypoints = 3;
    public Text console;
    public GameObject player;

    private NavMeshAgent agent;
    private Collider last;
    private GameObject[] targets;
    private int currentTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>() as NavMeshAgent;
        targets = new GameObject[numWaypoints];
        Vector3 origin = transform.position;
        float angle = 360/numWaypoints;

        for(int i=0; i<numWaypoints; i++)
        {
            targets[i]=new GameObject("Waypoint "+i);
            targets[i].transform.Translate(Vector3.forward * radius);
            targets[i].transform.RotateAround(origin, Vector3.up, angle * i);
            SphereCollider sc = targets[i].AddComponent<SphereCollider>( ) as SphereCollider;
            sc.radius = 1.5f;
            sc.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targets[currentTarget].transform.position;
        string debug = "";
        Vector3 point = transform.InverseTransformPoint(player.transform.position);
        double angle = Atan(point.z/point.x)*(180/PI);
        if(point.x < 0) angle += 180;
        angle -= 90;

        if(point.z > 0)
        {
            debug += "The player is in front\n";
        }
        else
        {
            debug += "The player is in behind\n";
        }

        debug += "Angle to player: "+angle+"\n";

        if( -45 < angle && angle < 45 && point.z > 0)
        {
            debug += "player is within FOV\n";
        }

        else
        {
            debug += "player is not within FOV\n";
        }
        console.text = debug;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(last != other) {
            currentTarget = (currentTarget + 1) % numWaypoints;
        }
        last = other;
    }
}
