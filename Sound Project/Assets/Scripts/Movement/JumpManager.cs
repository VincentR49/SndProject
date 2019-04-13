using UnityEngine;
using System.Collections;
using System;

// Managing Jump
[RequireComponent(typeof(Rigidbody))]
public class JumpManager : MonoBehaviour
{
    private const float Epsilon = 0.001f;

    [SerializeField]
    private float _jumpForce = 2f;

    private Rigidbody _rb;
    private bool _isJumping;
    private float _checkJumpingRefreshDelay = 0.1f;
    private float _previousVelocityY;

    private Vector3 Velocity => _rb.velocity;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void Jump()
    {
        if (CanJump())
        {
            _isJumping = true;
            _rb.AddForce (new Vector3 (0f, _jumpForce, 0f), ForceMode.VelocityChange);
            StartCoroutine(CheckIsJumping());
            Debug.Log("Start jump");
        }
    }

    IEnumerator CheckIsJumping()
    {
        while (_isJumping)
        {
            yield return new WaitForSeconds(_checkJumpingRefreshDelay);
            if (Velocity.y.Equals(0f) && _previousVelocityY.Equals(0f))
            {
                _isJumping = false;
                Debug.Log("Stop jump");
            }
            _previousVelocityY = Velocity.y;
        }
    }


    private bool CanJump() => !_isJumping;
}
