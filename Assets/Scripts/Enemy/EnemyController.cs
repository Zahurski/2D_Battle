using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHit
    {
        [SerializeField] private float dashSpeed = 3f;
        [SerializeField] private EnemyData enemyData;
        private EnemyScale _enemyScale;
        private CircleCollider2D _collider;
        private Health _health;

        private Vector3 _startPosition;
        private bool _active;
        private bool _hit;
        private float _enemyHealth;
        private float _enemyDamage;
        
        private void Start()
        {
            _startPosition = transform.position;
            Initialize();
        }

        private void Initialize()
        {
            if (_startPosition != transform.position)
            {
                transform.position = _startPosition;
            }
            
            _collider = GetComponent<CircleCollider2D>();
            _enemyScale = gameObject.GetComponent<EnemyScale>();
            _enemyScale.Initialize();
            _enemyScale.ScaleCompleted += ActivateEnemy;
            _collider.enabled = false;
            _enemyDamage = enemyData.Attack;
            _enemyHealth = enemyData.Health;
            _health = GetComponent<Health>();
            _health.SetMaxValue(_enemyHealth);
            _health.SetCurrentValue(_enemyHealth);
            _health.OnDie += Dead;
            _enemyDamage = enemyData.Attack;
        }

        private void ActivateEnemy()
        {
            _active = true;
            _hit = false;
            _collider.enabled = true;
        }

        private void Update()
        {
            switch (_hit)
            {
                case true when transform.position == _startPosition:
                    Hit();
                    _hit = false;
                    break;
                case true when transform.position != _startPosition:
                    ReturnPosition();
                    break;
                default:
                {
                    if(_active)
                    {
                        Hit();
                    }

                    break;
                }
            }
        }
        
        public void Hit()
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                PlayerController.Instance.transform.position, dashSpeed * Time.deltaTime);
        }

        private void ReturnPosition()
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                _startPosition, dashSpeed * Time.deltaTime);
            if(_hit) return;
            _hit = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerController>())
            {
                var health = other.gameObject.GetComponent<Health>();
                health.Decrease(_enemyDamage);
                _hit = true;
            }
        }

        private void Dead()
        {
            PlayerController.Instance.Count();
            _active = false;
            _health.OnDie -= Dead;
            _enemyScale.ScaleCompleted -= ActivateEnemy;
            Initialize();
        }
    }
}
