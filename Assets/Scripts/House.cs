using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter(Collider other)
    {
        _signaling.StartSignaling();
    }

    private void OnTriggerExit(Collider other)
    {
        _signaling.StartSignaling();
    }
}