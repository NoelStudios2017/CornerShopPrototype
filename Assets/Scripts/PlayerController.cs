using System;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions _playerInputActions;
    private Vector3 _input;
    CharacterController _characterController;

    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 360f;
    private void Awake()
    {
        _playerInputActions = new InputSystem_Actions(); 
        _characterController = GetComponent<CharacterController>();
    }

    //This ensures good logic for input
    private void OnEnable()
    {
        _playerInputActions.Player.Enable();
    }
    private void OnDisable()
    {
        _playerInputActions.Player.Disable();
    }

    private void Update()
    {
        GatherInput();
        Look();
        Move();
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        //create a matrix 4x4 
        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 multiplyMatrix = isometricMatrix.MultiplyPoint3x4(_input);

        Quaternion rotation = Quaternion.LookRotation(multiplyMatrix, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,rotationSpeed*Time.deltaTime);
    }

    private void Move()
    {
        Vector3 moveDirection= speed * _input.normalized*Time.deltaTime;
        _characterController.Move(moveDirection);
    }

    private void GatherInput()
    {
        Vector2 input = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _input = new Vector3(input.x, 0, input.y);
    }
}
