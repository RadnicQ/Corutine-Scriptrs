using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _updateTime = 0.5f;
    [SerializeField] private float _countStep = 1f;

    private float _realtimeCount = 0f;
    private bool _isCorutinePlay = false;

    public event Action<float> Count;

    public void SwitchCounter()
    {
        if (_isCorutinePlay == false)
        {
            _isCorutinePlay = true;
            OnCounter();
            return;
        }

        if (_isCorutinePlay == true)
        {
            _isCorutinePlay = false;
            OffCounter();
        }
    }

    private void OnCounter() => StartCoroutine(IncreaseInNumber());

    private void OffCounter() => StopCoroutine(IncreaseInNumber());

    private IEnumerator IncreaseInNumber()
    {
        while (_isCorutinePlay)
        {
            _realtimeCount += _countStep * Time.deltaTime / _updateTime;
            Count?.Invoke(_realtimeCount);

            yield return null;
        }
    }
}
