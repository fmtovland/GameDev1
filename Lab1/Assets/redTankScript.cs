using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class redTankScript : MonoBehaviour
{
    public float radius;
    public int numWaypoints = 3;
    public NavMeshAgent agent;

    public Collider last;
    private GameObject[] targets;
    private int currentTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        targets = new GameObject[numWaypoints];
        Vector3 origin = transform.position;
        float angle = 360/numWaypoints;

        for(int i=0; i<numWaypoints; i++)
        {
            targets[i]=new GameObject();
            targets[i].transform.Translate(Vector3.forward * radius);
            targets[i].transform.RotateAround(origin, Vector3.up, angle * i);
            SphereCollider sc = targets[i].AddComponent<SphereCollider>( ) as SphereCollider;
            sc.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = targets[currentTarget].transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(last != other) {
            currentTarget = (currentTarget + 1) % numWaypoints;
        }
        last = other;
    }
}
