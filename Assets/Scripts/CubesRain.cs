using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectPool))]
public class CubesRain : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 0.5f;

    private ObjectPool _pool;
    private Spawner<Cube> _cubeSpawner;
    private Coroutine _spawner;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
        _cubeSpawner = new Spawner<Cube>(_pool);
        _spawner = StartCoroutine(SpawnCube());
    }

    public Spawner<Cube> GetSpawner()
    {
        return _cubeSpawner;
    }

    private IEnumerator SpawnCube()
    {
        WaitForSeconds waitForSeconds = new(_spawnRate);

        while (true)
        {
            Cube cube = _cubeSpawner.Spawn();

            cube.Init();
            cube.transform.position = GetSpawnPosition();

            yield return waitForSeconds;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        int topCorner = 9;
        int bottomCorner = -9;
        int leftCorner = -9;
        int rightCorner = 9;
        int minHegith = 20;
        int maxHeight = 25;

        return new Vector3(Random.Range(leftCorner, rightCorner),
            Random.Range(minHegith, maxHeight), Random.Range(bottomCorner, topCorner));
    }
}