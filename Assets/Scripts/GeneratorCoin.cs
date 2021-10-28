using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneratorCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _path;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_coin, _points[i].position,Quaternion.identity);
        }
    }
}
