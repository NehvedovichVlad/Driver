using UnityEngine;

public class Ground : MonoBehaviour
{
    private Plane _plane;
    [SerializeField] private Transform _player;
    [SerializeField] private Ground _ground;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }
    private void Update()
    {
        //Vector3 localPosition = transform.InverseTransformPoint(_player.position);
        //Debug.Log(localPosition);
    }

    private void CreateGround()
    {
        Vector3 localPosition = transform.InverseTransformPoint(_player.position);

        if (Mathf.Abs(localPosition.x) > 0.25f)
        {
            Vector3 newPos = new Vector3(transform.position.x + (0.5f - localPosition.x), transform.position.y, transform.position.z);
            Instantiate(_ground, newPos, Quaternion.identity);
        }
        if (Mathf.Abs(localPosition.z) > 0.25f)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z * (0.5f - localPosition.z));
            Instantiate(_ground, newPos, Quaternion.identity);
        }
    }

  
}
