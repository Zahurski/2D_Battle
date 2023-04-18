using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float damage = 25f;
        private void Start()
        {
            StartCoroutine(Missing());
        }

        private void Update()
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<EnemyController>())
            {
                var health = col.gameObject.GetComponent<Health>();
                health.Decrease(damage);
                Destroy(gameObject);
            }
        }

        private IEnumerator Missing()
        {
            yield return new WaitForSeconds(4f);
            Destroy(gameObject);
        }
    }
}
