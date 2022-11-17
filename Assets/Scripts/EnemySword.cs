using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    public EnemyMov _enemy;
    public FPSController _player;
    public int _damage;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _enemy._isAttacking == true)
        {
            _player.TakeDamage(_damage);
            _enemy._isAttacking = false;
        }
    }
}
