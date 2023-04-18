using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnDie = null;

    private float _maxValue = 0f;
    private float _currentValue = 0f;
    private bool _isDead = false;

    public float CurrentValueNormalized 
    {
        get
        {
            return _currentValue / _maxValue;
        }
    }

    public void SetMaxValue(float value)
    {
        _maxValue = value;
    }

    public void SetCurrentValue(float value)
    {
        _currentValue = value;
    }

    public void Reset()
    {
        _currentValue = _maxValue;
        _isDead = false;
    }

    public void Decrease(float value)
    {
        if (_isDead) return;

        _currentValue = Mathf.Clamp(_currentValue - value, 0f, _maxValue);
        CheckState();
    }

    private void CheckState()
    {
        if (_currentValue == 0)
        {
            OnDie?.Invoke();
        } 
    }
}
