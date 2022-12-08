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
    public bool _isDeath;

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
        _isDeath = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        _minRotation = -65f;
        _maxRotation = 60f;
        _mouseHorizontal = 3f;
        _mouseVertical = 2f;
        _characterControler = GetComponent<CharacterController>();
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
        _audioSource = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.Escape) && _isDeath == false)
        {
            PauseGame(1);
        }

      _move.y -= _gravity * Time.deltaTime;

        _characterControler.Move(_move * Time.deltaTime);
    }


    [Header("Barra de Vida")]

    public HealthBar _healthBar;

    public int _maxHealth = 100;
    public int _currentHealth;
    public GameObject _deathMenu;
    public GameObject _pauseMenu;

    [Header("Audio")]
    public AudioClip _hitSound;
    public AudioSource _audioSource;


    public void TakeDamage(int damage)
    {
        _audioSource.PlayOneShot(_hitSound);
        
        _currentHealth -= damage;

        _healthBar.SetHealth(_currentHealth);

        CheckHealth();
    }

    public LobbyController _lobby;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("NPC"))
        {
            Debug.Log("Toco");
            _lobby.GameMomentStart();
        }
    }

    public void CheckHealth()
    {
        if (_currentHealth <= 0 && _isDeath == false)
        {
            PauseGame(0);
        }
    }

    public void PauseGame(int pauseOrDeath)
    {
        if (pauseOrDeath == 0)
        {
            _deathMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            _minRotation = 0f;
            _maxRotation = 0f;
            _mouseHorizontal = 0f;
            _mouseVertical = 0f;
            _isDeath = true;
        }

        if (pauseOrDeath == 1)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            _minRotation = 0f;
            _maxRotation = 0f;
            _mouseHorizontal = 0f;
            _mouseVertical = 0f;
        }

        if (pauseOrDeath == 2)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            _minRotation = -65f;
            _maxRotation = 60f;
            _mouseHorizontal = 3f;
            _mouseVertical = 2f;
        }
    }
}
