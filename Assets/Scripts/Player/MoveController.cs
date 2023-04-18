using System;
using UnityEngine;

namespace Player
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        
        private SpriteRenderer _sprite;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var dir = transform.right * Input.GetAxis("Horizontal");
            var position = transform.position;
            var posX = Mathf.Clamp(position.x, -2.5f, 2.5f);
            var newPos = new Vector3(posX, position.y, position.z);
            position = Vector3.MoveTowards(position, newPos + dir, speed * Time.deltaTime);
            transform.position = position;
            _sprite.flipX = dir.x < 0.0f;
        }
    }
}
