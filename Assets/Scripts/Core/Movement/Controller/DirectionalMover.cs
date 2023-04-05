using Core.Movement.Data;
using StatsSystem;
using StatsSystem.Enum;
using UnityEngine;

namespace Core.Movement.Controller
{
    public class DirectionalMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly DirectionalMovementData _directionalMovementData;
        private readonly IStatValueGiver _statValueGiver;

        private Vector2 _movement;

        public DirectionalMover(Rigidbody2D rigidbody, DirectionalMovementData directionalMovementData, 
            IStatValueGiver statValueGiver)
        {
            _rigidbody = rigidbody;
            _directionalMovementData = directionalMovementData;
            _statValueGiver = statValueGiver;
        }
        
        public void Move(float horizontalDirection, float verticalDirection)
        {
            _movement = new Vector2(horizontalDirection, verticalDirection);
            _rigidbody.MovePosition(_rigidbody.position + _movement 
                * (_statValueGiver.GetStatValue(StatType.Speed) * Time.fixedDeltaTime));
        }
    }
}