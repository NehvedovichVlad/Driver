using UnityEngine;

enum Direction { 
    Up,
    Down,
    Left,
    Right
}

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMovePrefab;
    [SerializeField] private Transform _target;

    [SerializeField] private Transform _spawnZone;
    [SerializeField] private PlayerController _playerController;

    private Vector3 _dir = new();

    private float _timer;

    private void Update()
    {

        _dir = _playerController.SetDirection();

        _timer += Time.deltaTime;

        if (_timer > 3f)
        {
            _timer = 0f;
            EnemyMove newEnemy = Instantiate(_enemyMovePrefab, GetPointInsideZone(), Quaternion.identity);
            newEnemy.SetTarget(_target);
        }
    }

    private Vector3 GetPointInsideZone()
    {
        float x = 0;
        float y = 0f;
        float z = 0;

        float x1 = Random.Range(0.51f, 1f);
        float x2 = Random.Range(-1f, -0.51f);


        float z1 = Random.Range(0.51f, 1f);
        float z2 = Random.Range(-1f, -0.51f);

        if (_dir.x > 0 )
        {
            x = x1;
        }
        else
        {
            x = x2;
        }

        if (_dir.z > 0)
        {
            z = z1;
        }
        else
        {
            z = z2;
        }

        Vector3 worldPosition = _spawnZone.TransformPoint(x, y, z);
        worldPosition.y = 0f;

        return worldPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_spawnZone.position, _spawnZone.localScale);
    }
}
