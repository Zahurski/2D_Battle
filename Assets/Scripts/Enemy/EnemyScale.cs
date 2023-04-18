using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyScale : EnemyController
    {
        private const float InitialScaleTime = 5.0f;
        private readonly Vector3 _startingScale = Vector3.one * 0.05f;
        private readonly Vector3 _endingScale = Vector3.one * 0.5f;
 
        private float _lerpT;
        private float _fScaleTime;
        private bool _scaleActive = true;
 
        
        public event Action ScaleCompleted;
        private void Start()
        {
            ScaleTime = InitialScaleTime;
            _lerpT = 0f;
        }
 
        private void Update()
        {
            if(!_scaleActive) return;
            
            transform.localScale = Vector3.Lerp(_startingScale, _endingScale, _lerpT * _fScaleTime);
            _lerpT += Time.deltaTime;
            
            if (_lerpT > InitialScaleTime)
            {
                _scaleActive = false;
                ScaleCompleted?.Invoke();
            }
        }

        private float ScaleTime
        {
            set
            {
                if(value == 0f)
                {
                    _fScaleTime = 0f;
                }
                else
                {
                    _fScaleTime = 1.0f / value;
                }
            }
        }
    }
}
