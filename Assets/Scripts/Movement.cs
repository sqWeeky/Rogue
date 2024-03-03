using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timer;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;
    private float _delayTime;

    private void Start()
    {
        _delayTime = _timer;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_spot].position, _speed * Time.deltaTime);

        if (_timer <= 0)
        {
            _spot = (_spot == 1) ? 0 : 1;
            _timer = _delayTime;
        }

        _timer -= Time.deltaTime;
    }
}