using System;
using System.Collections;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHit
    {
        [SerializeField] private float dashSpeed = 3f;
        private EnemyScale _enemyScale;
        private CircleCollider2D _collider;

        private Vector3 _startPosition;
        private bool _active;
        
        private void Start()
        {
            _startPosition = transform.position;
            _collider = GetComponent<CircleCollider2D>();
            _enemyScale = gameObject.GetComponent<EnemyScale>();
            _enemyScale.ScaleCompleted += ActivateEnemy;
            _collider.enabled = false;
        }

        private void ActivateEnemy()
        {
            _active = true;
            _collider.enabled = true;
        }

        private void Update()
        {
            if(!_active)
            {
                ReturnPosition();
            }
            else
            {
                Hit();
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
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerController>())
            {
                _active = false;
            }
        }
    }
}
