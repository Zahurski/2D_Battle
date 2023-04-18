using System;
using UnityEngine;

namespace Player
{
    public class Shooting : MonoBehaviour, IHit
    {
        [SerializeField] private GameObject bulletPrefab;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Hit();
        }

        public void Hit()
        {
            RotationWeapon();
            
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }
        
        private void RotationWeapon()
        {
            var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            var aimDirection = mousePos - transform.position;
            var rotZ = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f,0f, rotZ);
        }
    }
}
