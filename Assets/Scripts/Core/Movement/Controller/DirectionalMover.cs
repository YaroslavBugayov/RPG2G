using Core.Movement.Data;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class DirectionalMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly DirectionalMovementData _directionalMovementData;

        private Vector2 _movement;

        public DirectionalMover(Rigidbody2D rigidbody, DirectionalMovementData directionalMovementData)
        {
            _rigidbody = rigidbody;
            _directionalMovementData = directionalMovementData;
        }
        
        public void Move(float horizontalDirection, float verticalDirection)
        {
            _movement = new Vector2(horizontalDirection, verticalDirection);
            _rigidbody.MovePosition(_rigidbody.position + _movement 
                * (_directionalMovementData.Speed * Time.fixedDeltaTime));
        }
    }
}