using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable() => _counter.Count += VievNumber;

    private void OnDisable() => _counter.Count -= VievNumber;

    private void VievNumber(float number) => _text.text = number.ToString();
}
