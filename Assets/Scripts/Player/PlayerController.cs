using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour, IHit
    {
        public static PlayerController Instance = null;

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
            
        }

        private void Update()
        {
        
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }
    }
}
