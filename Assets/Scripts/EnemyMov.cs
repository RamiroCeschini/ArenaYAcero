using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    public Transform _target;
    public NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("tracking", 2.0f, 1.0f);
    }

    private void tracking()
    {
        _agent.destination = _target.position;
    }

    
}
