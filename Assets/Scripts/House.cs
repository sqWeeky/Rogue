using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;    

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Rogue") == true)
            _signaling.StartSignaling();
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Rogue") == true)
            _signaling.StartSignaling();
    }
}