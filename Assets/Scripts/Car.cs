using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Rigidbody _rig;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _forwardFrtiction = 0.1f;
    [SerializeField] private float _sideFriction = 0.1f;

    private float _vertical;
    private float _horizontal;
    private bool _grounded;

    [SerializeField] private Transform _com;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rig.centerOfMass = _com.localPosition;

    }

    private void FixedUpdate()
    {
        if (Vector3.Angle(Vector3.up, transform.up) > 20f)
        {
            _grounded = false;
        }

        if (!_grounded) return;

        Vector3 velocityRelativeToCar = transform.InverseTransformVector(_rig.velocity);

        float mult = Mathf.InverseLerp(0, 5f, velocityRelativeToCar.z);

        _rig.AddRelativeForce(0, 0, 1 * _speed, ForceMode.VelocityChange);
        _rig.AddRelativeTorque(0, _horizontal * _rotationSpeed * mult, 0,  ForceMode.VelocityChange);

        _rig.AddRelativeForce(0, 0, -velocityRelativeToCar.z * _forwardFrtiction, ForceMode.VelocityChange);
        _rig.AddRelativeForce(-velocityRelativeToCar.x * _sideFriction, 0, 0,  ForceMode.VelocityChange);

    }

    public void SetDriveValues(float vertical, float horizontal)
    {
        _vertical = vertical;
        _horizontal = horizontal;
    }

    private void OnCollisionStay(Collision collision)
    {
        _grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
