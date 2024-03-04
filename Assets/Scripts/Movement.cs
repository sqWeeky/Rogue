using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;

    private void Start()
    {
        StartMove();
    }

    private Vector3 GetNextSpot()
    {
        if (_spot == _moveSpots.Length - 1)
            _spot = 0;
        else
            _spot++;

        return _moveSpots[_spot].position;
    }

    private void StartMove()
    {
        transform.DOMove(GetNextSpot(), _speed).SetEase(Ease.Linear).OnComplete(() =>
        { 
            StartMove();
        });        
    }    
}