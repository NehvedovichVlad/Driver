using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Rigidbody _rigCar;
    private Vector3 _carDirection = new();
    private void Update()
    {
       float  v = Input.GetAxis("Vertical");
       float h = Input.GetAxis("Horizontal");

        _car.SetDriveValues(v, h);
    }

    public Vector3 SetDirection()
    {
        _carDirection = _rigCar.velocity;
        return _carDirection;
    }
}
