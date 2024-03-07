using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _rateChangeOfSound;

    private float _minVoluve = 0f;
    private float _maxVoluve = 1f;
    private Coroutine _coroutine;
    private float _targetValue;

    private void Start()    
        =>_audioSource.volume = _minVoluve;    

    public void StartSignaling()
    {
        if (_targetValue == _minVoluve)
            _targetValue = _maxVoluve;
        else
            _targetValue = _minVoluve;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolumeAudioSource());
    }

    private IEnumerator ChangeVolumeAudioSource()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != _targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetValue, _rateChangeOfSound * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }    
}