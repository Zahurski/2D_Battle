using UnityEngine;

namespace Enemy
{
    public class EnemyScale : MonoBehaviour
    {
        private const float InitialScaleTime = 5.0f;
        private readonly Vector3 _startingScale = Vector3.one * 0f;
        private readonly Vector3 _endingScale = Vector3.one * 0.5f;
 
        private float _lerpT;
 
        private void Start()
        {
            ScaleTime = InitialScaleTime;
            _lerpT = 0f;
        }
 
        private void Update()
        {
            transform.localScale = Vector3.Lerp(_startingScale, _endingScale, _lerpT * _fScaleTime);
            _lerpT += Time.deltaTime;
        }
        
        private float _fScaleTime;

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
