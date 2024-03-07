using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timer;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;
    private int _nextSpot;
    private float _minDistanse = 0.2f;

    private void Start()
       => StartCoroutine(Move());

    private IEnumerator Move()
    {
        var waitForSeconds = new WaitForSeconds(_timer);

        while (Vector3.Distance(transform.position, _moveSpots[_spot].position) > _minDistanse)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_spot].position, _speed * Time.deltaTime);
            yield return null;
        }

        _nextSpot = _spot + 1;
        _spot = _nextSpot % _moveSpots.Length;

        yield return waitForSeconds;
        StartCoroutine(Move());
    }
}