using Core.Movement.Controller;
using Core.Movement.Data;
using Player.PlayerAnimation;
using StatsSystem;
using StatsSystem.Enum;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private DirectionalMovementData _directionalMovementData;
        [SerializeField] private UnityEvent<float> hpChangedProcent;
        [SerializeField] private UnityEvent<float> energyChangedProcent;
        [SerializeField] private UnityEvent die;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private DirectionalMover _directionalMover;
        private AnimatorController _animatorController;
        
        private float _maxHp;
        private float _maxEnergy;
        private float _hp;
        private float _energy;

        
        private float HP
        {
            get => _hp;
            set
            {
                _hp = value;
                hpChangedProcent?.Invoke(_hp/_maxHp);
                if (_hp <= 0)
                {
                    die?.Invoke();
                }
            }
        }

        private float Energy
        {
            get => _energy;
            set
            {
                _energy = value;
                energyChangedProcent?.Invoke(_energy/_maxEnergy);
            }
        }
        
    
        public void Initialize(IStatValueGiver statValueGiver)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData, statValueGiver);
            _animatorController = new AnimatorController(_animator);
            _maxHp = statValueGiver.GetStatValue(StatType.Health);
            _maxEnergy = statValueGiver.GetStatValue(StatType.Energy);
            _hp = _maxHp;
            _energy = _maxEnergy;
        }

        public void Use()
        {
            
            
        }

        public void Move(float horizontalDirection, float verticalDirection)
        {
            _directionalMover.Move(horizontalDirection, verticalDirection);
            _animatorController.SetValues(horizontalDirection, verticalDirection);
        }
        
        public void GetDamage(float damage = -3)
        {
            HP = _hp + damage;
        }
        
        public void UseEnergy(float energy = -3)
        {
            Energy = _energy + energy;
        }

    }
}
