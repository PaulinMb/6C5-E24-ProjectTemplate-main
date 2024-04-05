using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent capsule;

    public GameObject goal;
    public bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        capsule = GetComponent<NavMeshAgent>();
        capsule.updateRotation = false;
        capsule.transform.RotateAround(Vector3.left, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            capsule.SetDestination(goal.transform.position);
        }
    }
}

