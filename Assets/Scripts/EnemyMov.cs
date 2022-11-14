using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    public Transform _target;
    public NavMeshAgent _agent;
    public bool _isAttacking = false;
    public float _animationTime = 2f;
    public float _stoppingDistance = 2f;
    public bool _isDeath = false;
    public float _attackDelay = 0.8f;

    public Animator _anim;

    public AudioClip _gruntSound;
    public AudioClip _deathSound;
    public AudioClip _hitSound;
    public AudioSource _audioSource;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Invoke("WhatToDo", 2f);

        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);

        _audioSource = GetComponent<AudioSource>();
    }

    void WhatToDo()
    {
        if (_agent.remainingDistance <= _stoppingDistance && _isDeath == false)
        {
            Attack();
        }
        else if (_agent.remainingDistance > _stoppingDistance && _isDeath == false)
        {
            Tracking();
        }
    }

    void Tracking()
    {
        if (_isDeath == false)
        {
            _anim.SetBool("isMoving", true);
            _agent.isStopped = false;
            _isAttacking = false;
            _agent.destination = _target.position;
            Invoke("WhatToDo", 0.2f);
        }
    }

    void Attack()
    {
        if (_isDeath == false)
        {
            _agent.isStopped = true;
            _anim.SetBool("isMoving", false);
            _anim.SetTrigger("Attack");
            Invoke("DamageDelay", _attackDelay);
            Invoke("Tracking", _animationTime);
        }
      
    }

    void DamageDelay()
    {
        _isAttacking = true;
        _audioSource.PlayOneShot(_gruntSound);
    }

    [Header("Barra de Vida")]

    public HealthBar _healthBar;

    public int _maxHealth = 60;
    public int _currentHealth;
    public WeaponController _playerSword;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSword") && _playerSword._didAttack == true)
        {
            TakeDamage(15);
        }
    }

    void TakeDamage(int damage)
    {
        if (_isDeath == false)
        {
            _currentHealth -= damage;

            _healthBar.SetHealth(_currentHealth);

            _playerSword._didAttack = false;

            _audioSource.PlayOneShot(_hitSound);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        _anim.SetTrigger("Death");
        _anim.SetBool("isAlive", false);
        _isDeath = true;
        _agent.isStopped = true;
        _audioSource.PlayOneShot(_deathSound);
    }

}
