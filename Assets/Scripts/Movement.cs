using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timer;
    [SerializeField] private Transform[] _moveSpots;

    private int _spot = 0;
    private int _nextSpot;

    private void Start()
       => StartCoroutine(Move());

    private IEnumerator Move()
    {
        while (Vector3.Distance(transform.position, _moveSpots[_spot].position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_spot].position, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        _nextSpot = _spot + 1;
        _spot = _nextSpot % _moveSpots.Length;

        yield return new WaitForSeconds(_timer);
        StartCoroutine(Move());
    }
}