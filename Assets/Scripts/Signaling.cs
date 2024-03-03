using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeDelta;

    private float _minVoluve = 0;
    private float _maxVoluve = 1;
    private bool _isActive;

    private void Start()
    {
        _audioSource.volume = _minVoluve;
    }

    public void StartSignaling()
    {
        _audioSource.Play();
        StopAllCoroutines();

        if (_isActive == false)
        {
            StartCoroutine(IncreaseSound());
            _isActive = true;
        }
        else
        {
            StartCoroutine(ReductionSound());
            _isActive = false;
        }
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

        _audioSource.Stop();
    }
}