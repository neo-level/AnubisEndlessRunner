using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject shield;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SfxManager sFXManager;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private UIController gameOver;

    private bool _doubleJump;
    private bool _hasShield;
    private bool _isOnGround;
    private bool _jump;

    private const float JumpForce = 7.0f;
    private float _lastYPosition;

    private static readonly int IsFalling = Animator.StringToHash("isFalling");
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    private static readonly int Jump = Animator.StringToHash("Jump");

    public int collectable;
    public float distanceTravelled = 0;


    private void Start()
    {
        _lastYPosition = transform.position.y;
    }

    private void Update()
    {
        CheckForInput();
        CheckForFalling();
        distanceTravelled += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        CheckForJump();
    }

    private void CheckForInput()
    {
        if (_isOnGround || _doubleJump)
        {
            if (Input.GetKeyDown(key: KeyCode.Space))
            {
                if (_doubleJump && !_isOnGround)
                {
                    sFXManager.PlaySfx("DoubleJump");
                    _doubleJump = false;
                }

                sFXManager.PlaySfx("Jump");
                _jump = true;
                _isOnGround = false;
                animator.SetTrigger(Jump);
                animator.SetBool(IsGrounded, false);
            }
        }
    }

    private void CheckForFalling()
    {
        if (transform.position.y < _lastYPosition)
        {
            animator.SetBool(IsFalling, true);
        }
        else
        {
            animator.SetBool(IsFalling, false);
        }

        _lastYPosition = transform.position.y;
    }

    private void CheckForJump()
    {
        if (_jump)
        {
            sFXManager.PlaySfx("Jump");
            _jump = false;
            rigidbody.AddForce(new Vector2(x: 0, y: JumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("obstacle"))
        {
            if (_hasShield)
            {
                Destroy(other.gameObject);
                sFXManager.PlaySfx("ShieldBreak");
                _hasShield = false;
                shield.SetActive(false);
            }
            else
            {
                sFXManager.PlaySfx("GameOverHit");
                gameOver.GameOver();
            }
        }

        if (other.transform.CompareTag("DeathBox"))
        {
            gameOver.GameOver();
        }

        if (other.transform.CompareTag("Ground"))
        {
            sFXManager.PlaySfx("Land");
            _isOnGround = true;
            animator.SetBool(IsGrounded, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            collectable++;
            sFXManager.PlaySfx("Coin");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("DoubleJump"))
        {
            _doubleJump = true;
            sFXManager.PlaySfx("PowerUpDoubleJump");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Shield"))
        {
            _hasShield = true;
            sFXManager.PlaySfx("PowerUpShield");
            shield.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        gameOver.GameOver();
    }
}