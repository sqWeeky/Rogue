using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeDelta;

    private float _minVoluve = 0;
    private float _maxVoluve = 1;

    private void Start()
    {
        _audioSource.volume = _minVoluve;
        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(IncreaseSound());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ReductionSound());
    }

    private IEnumerator IncreaseSound()
    {
        while (_audioSource.volume < _maxVoluve)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVoluve, _volumeDelta * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator ReductionSound()
    {
        while (_audioSource.volume > _minVoluve)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVoluve, _volumeDelta * Time.deltaTime);
            yield return null;
        }
    }
}