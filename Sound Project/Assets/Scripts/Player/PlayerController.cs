using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control the player movement
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private JumpManager _jumpManager;
    [SerializeField]
    private MoveManager _moveManager;
    [SerializeField]
    private RotateManager _cameraRotateManager;
    [SerializeField]
    private RotateManager _playerRotateManager;


    private void Update()
    {
        GetAxisDirection();
        if (Input.GetKey(KeyCode.Space))
        {
            _jumpManager.Jump();
        }
        _moveManager.Move(GetAxisDirection());
        _playerRotateManager.Rotate(Input.GetAxis("Mouse X"));
        _cameraRotateManager.Rotate(Input.GetAxis("Mouse Y"));
    }


    private Vector3 GetAxisDirection()
    {
        return new Vector3 (Input.GetAxis("Horizontal"),
                            0,
                            Input.GetAxis("Vertical"));
    }
}
