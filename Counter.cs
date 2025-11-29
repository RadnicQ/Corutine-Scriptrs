using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _updateTime = 0.5f;
    [SerializeField] private float _stepValue = 1f;

    private float _realtimeValue = 0f;
    private bool _isCorutinePlay = false;

    public event Action<float> Counting;

    public void SwitchTimer()
    {
        if (_isCorutinePlay == false)
        {
            _isCorutinePlay = true;
            OnTimer();
            return;
        }

        if (_isCorutinePlay == true)
        {
            _isCorutinePlay = false;
            OffTimer();
        }
    }

    private void OnTimer() => 
        StartCoroutine(IncreaseInNumber());

    private void OffTimer() => 
        StopCoroutine(IncreaseInNumber());

    private IEnumerator IncreaseInNumber()
    {
        WaitForSeconds updateTime = new WaitForSeconds(_updateTime);

        while (_isCorutinePlay)
        {
            yield return updateTime;

            _realtimeValue += _stepValue;
            Counting?.Invoke(_realtimeValue);
        }
    }
}
