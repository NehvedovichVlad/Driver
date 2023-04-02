using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void Update()
    {
        transform.position = _target.position;
    }
}
