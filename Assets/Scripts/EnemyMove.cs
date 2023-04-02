using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(toPlayer);

        _rigidbody.velocity = toPlayer * _speed;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
