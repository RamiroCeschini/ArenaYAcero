using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject _sword;
    public bool _canAttack = true;
    public float _attackCooldown = 1f;
    public bool _swordposition = true; //true = derecha false = izquierda

    public AudioClip _swordAttackSound;
    public AudioClip _swordAttackSound2;
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canAttack == true && _swordposition == true)
            {
                _swordAttack();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (_canAttack == true && _swordposition == false)
            {
                _swordAttack();
            }
        }
    }

    public void _swordAttack()
    {
       if (_swordposition == true)
        {
            _swordposition = false;
        }
       else if (_swordposition == false)
        {
            _swordposition = true;

        }

        _canAttack = false;
        Animator _anim = _sword.GetComponent<Animator>();
        _anim.SetTrigger("Atack");

        AudioSource _audioSource = GetComponent<AudioSource>();
        if (_swordposition == true)
        {
            _audioSource.PlayOneShot(_swordAttackSound);
        }

        else
        {
            _audioSource.PlayOneShot(_swordAttackSound2);
        }
       
        StartCoroutine(ResetAttackCoolDown());
    }

    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}
