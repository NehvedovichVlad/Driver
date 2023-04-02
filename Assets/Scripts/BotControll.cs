using UnityEngine;

public class BotControll : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Path _path;
    [SerializeField] private float _vertical = 1f;

    [SerializeField] private int _checkpointIndex = 0;
    private float _checkpointRadius = 2f;
    private void Update()
    {
        Vector3 toTarget = _path.CheckPoints[_checkpointIndex].position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
        Vector3 cross = Vector3.Cross(transform.forward, toTargetXZ.normalized);
        float horizontal = cross.y;
        _car.SetDriveValues(_vertical, horizontal);

        float distance = Vector3.Distance(transform.position, _path.CheckPoints[_checkpointIndex].position);
        if (distance < _checkpointRadius)
        {
            _checkpointIndex++;
            Debug.Log(_checkpointIndex);
            if (_checkpointIndex == _path.CheckPoints.Length)
            {
                _checkpointIndex = _path.CheckPoints.Length - 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _checkpointRadius);
    }
}
     