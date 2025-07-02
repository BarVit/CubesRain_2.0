using UnityEngine;
using System.Collections;

public class CubeSpawner : Spawner
{
    [SerializeField] private float _spawnRate = 0.5f;

    private Coroutine _spawner;

    private void Start()
    {
        _spawner = StartCoroutine(SpawnCube());
    }

    private IEnumerator SpawnCube()
    {
        WaitForSeconds waitForSeconds = new(_spawnRate);

        while (true)
        {
            Cube cube = (Cube)Pool.Get();

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