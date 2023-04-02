using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private Transform _spawn;
    private bool _checkSpawn = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_checkSpawn)
        {
            Vector3 newSpawn = new Vector3(_spawn.position.x, -0.5f, _spawn.position.z);
            Instantiate(_groundPrefab, newSpawn, Quaternion.identity);
            _checkSpawn = true;
        }
    }
}
