using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Mover rogue))
            _alarm.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Mover rogue))
            _alarm.TurnOff();
    }
}