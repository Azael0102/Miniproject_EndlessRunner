using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            FindObjectOfType<MapGenerator>().SpawnSegment();
        }
    }
}