using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    public Transform _target;
    public NavMeshAgent _agent;
    public bool _isMoving = false;
    public float _stopDistance = 5f;
    public bool _isAttacking = false;

    public Animator _anim;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Invoke("tracking", 2.0f);
    }

    private void tracking()
    {
        _agent.destination = _target.position;
        _isAttacking = false;
        _isMoving = true;
        _anim.SetBool("IsMoving", true);
        _agent.isStopped = false;
        Invoke("tracking", 1f);
      

    }

    private void Update()
    {
       if ( _agent.remainingDistance <= _stopDistance)
        {
            _isAttacking = true;
            _agent.isStopped = true;
            _anim.SetBool("IsMoving", false);
            _anim.SetTrigger("Hit");
            _isMoving = false;
            Invoke("tracking", 2f);
        }
    }
}
