using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    CharacterController _characterControler;

    [Header("Opciones de Personaje")]
    public float _walkSpeed = 6.0f;
    public float _runSpeed = 10.0f;
    public float _jumpSpeed = 8.0f;
    public float _gravity = 20.0f;

    [Header("Opciones de Camara")]
    public Camera _cam;
    public float _mouseHorizontal = 3.0f;
    public float _mouseVertical = 2.0f;
    public float _minRotation = -65.0f;
    public float _maxRotation = 60.0f;
    float h_mouse, v_mouse;


    private Vector3 _move = Vector3.zero;


    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        _characterControler = GetComponent<CharacterController>();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    void Update()
    {
        h_mouse = _mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += _mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse,_minRotation,_maxRotation);

        _cam.transform.localEulerAngles = new Vector3 (-v_mouse, 0, 0 );
        transform.Rotate(0, h_mouse, 0);

        if (_characterControler.isGrounded)
        {
            _move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _move = transform.TransformDirection(_move) * _runSpeed;
            }
            else
            {
                _move = transform.TransformDirection(_move) * _walkSpeed;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                _move.y = _jumpSpeed;
            }
           
        }   

      _move.y -= _gravity * Time.deltaTime;

        _characterControler.Move(_move * Time.deltaTime);
    }

    // Take Damage

    public HealthBar _healthBar;

    public int _maxHealth = 100;
    public int _currentHealth;
    public EnemyMov _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword") && _enemy._isAttacking)
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _healthBar.SetHealth(_currentHealth);
    }
}
