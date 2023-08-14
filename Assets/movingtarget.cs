using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingtarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform[] waypoints;
    int currentwaypoint;
    Rigidbody rigi;
    [SerializeField]
    float movespeed = 150;


    void Start()
    {
        rigi=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }
    void Movment()
    {
        if (Vector3.Distance(transform.position, waypoints[currentwaypoint].position)<0.25f)
        {
            currentwaypoint += 1;
            currentwaypoint = currentwaypoint % waypoints.Length;

        }
        Vector3 _dir = (waypoints[currentwaypoint].position - transform.position).normalized;
        rigi.MovePosition(transform.position+_dir*movespeed*Time.deltaTime);

    }
}
