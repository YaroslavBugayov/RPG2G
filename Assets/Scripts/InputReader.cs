using System;
using Player;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private float _directionX;
    private float _directionY;
    
    private void Update()
    {
        _directionX = Input.GetAxis("Horizontal");
        _directionY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveHorizontally(_directionX, _directionY);
    }
}