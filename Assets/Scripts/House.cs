using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private GameObject _player;
    private Collider _playerCollider;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerCollider = _player.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _signaling.FadeIn();
    }

    private void OnTriggerExit(Collider other)
    {
        _signaling.FadeOut();
    }
}