using UnityEngine;

public class CubeToBombReplacer : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;
    [SerializeField] private CubesRain _cubesRain;

    private Spawner<Bomb> _bombSpawner;
    private Spawner<Cube> _cubeSpawner;

    private void Awake()
    {
        _bombSpawner = new Spawner<Bomb>(_prefab);
        _bombSpawner.Initialize();
    }

    private void Start()
    {
        _cubeSpawner = _cubesRain.GetSpawner();
        _cubeSpawner.OnObjectReleased += SpawnBomb;
    }

    private void OnDestroy()
    {
        _cubeSpawner.OnObjectReleased -= SpawnBomb;
    }

    public Spawner<Bomb> GetSpawner()
    {
        return _bombSpawner;
    }

    private void SpawnBomb(SpawnObject cube)
    {
        Bomb bomb = _bombSpawner.Get();
        Rigidbody bombRigidbody = bomb.GetComponent<Rigidbody>();
        Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

        bomb.transform.position = cube.transform.position;
        bomb.transform.rotation = cube.transform.rotation;
        bombRigidbody.velocity = cubeRigidbody.velocity;
        bombRigidbody.angularVelocity = cubeRigidbody.angularVelocity;

        bomb.Explode();
    }
}