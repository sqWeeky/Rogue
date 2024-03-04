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
        if (!_audioSource.isPlaying)
            _audioSource.Play();

        StopAllCoroutines();

        if (_isActive == false)
        {
            StartCoroutine(IncreaseSound());
            _isActive = true;
            return;
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
            ChangeVolume(_maxVoluve);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator ReductionSound()
    {
        while (_audioSource.volume > _minVoluve)
        {
            ChangeVolume(_minVoluve);
            yield return new WaitForEndOfFrame();
        }

        _audioSource.Stop();
    }

    private void ChangeVolume(float value)
        => _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, value, _volumeDelta * Time.deltaTime);

}