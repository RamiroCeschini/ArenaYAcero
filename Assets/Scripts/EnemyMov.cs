using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    [Header("Movement")]
    public Transform _target;
    public NavMeshAgent _agent;

    [Header("Animations")]
    public bool _isAttacking = false;
    public float _animationTime = 2f;
    public float _stoppingDistance = 2f;
    public bool _isDeath = false;
    public float _attackDelay = 0.8f;
    public Animator _anim;

    [Header("Audio")]

    public AudioClip _gruntSound;
    public AudioClip _deathSound;
    public AudioClip _hitSound;
    public AudioSource _audioSource;


    [Header("Health Bar")]

    public HealthBar _healthBar;
    public int _maxHealth = 60;
    public int _currentHealth;
    public WeaponController _playerSword;
    public KillCounter _killCounter;



    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _playerSword = GameObject.FindGameObjectWithTag("WeaponHolder").GetComponent<WeaponController>();
        _healthBar = GameObject.FindGameObjectWithTag("EnemyBar").GetComponent<HealthBar>();
        _killCounter = GameObject.FindGameObjectWithTag("KillCounter").GetComponent<KillCounter>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Invoke("WhatToDo", 2f);
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);

      
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
            _isAttacking = false;
            _agent.isStopped = true;
            _anim.SetBool("isMoving", false);
            _anim.SetTrigger("Attack");
            Invoke("DamageDelay", _attackDelay);
            Invoke("Tracking", _animationTime);

            Debug.Log("Ataco");
        }
      
    }

    void DamageDelay()
    {
        _isAttacking = true;
        _audioSource.PlayOneShot(_gruntSound);
        Debug.Log("DamageDelay");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSword") && _playerSword._didAttack == true)
        {
            TakeDamage(15);
            Debug.Log("Colision");
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

            Debug.Log("Causo Daño");

            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        _killCounter.KillCount();
        _isAttacking = false;
        _anim.SetTrigger("Death");
        _anim.SetBool("isAlive", false);
        _isDeath = true;
        _agent.isStopped = true;
        _audioSource.PlayOneShot(_deathSound);
        Debug.Log("Murio");

    }

}
