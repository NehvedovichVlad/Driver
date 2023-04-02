using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float LerpRate;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * LerpRate);

        //var direction = _target.position - transform.position;
        //var rotation = Quaternion.LookRotation(direction, Vector3.up);

        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }
}
