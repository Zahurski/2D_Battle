using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance = null;
        private Health _health;
        private float _healthValue = 100f;
        private int _enemyCounter = 0;

        public int EnemyCounter => _enemyCounter;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _health = GetComponent<Health>();
            _health.SetMaxValue(_healthValue);
            _health.SetCurrentValue(_healthValue);
            _health.OnDie += Dead;
        }

        private void Dead()
        {
            _health.OnDie -= Dead;
            LoadingScene.Instance.LoadScene(2);
        }

        public void Count()
        {
            _enemyCounter++;
        }
    }
}
