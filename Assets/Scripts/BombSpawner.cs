using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private Pool<Shape3D> _cubePool;

    private void Start()
    {
        _cubePool = _cubeSpawner.GetPool();
        _cubePool.OnObjectReleased += SpawnBomb;
    }

    private void OnDestroy()
    {
        _cubePool.OnObjectReleased -= SpawnBomb;
    }

    private void SpawnBomb(Shape3D cube)
    {
        Bomb bomb = (Bomb)Pool.Get();

        bomb.Init(cube);
        bomb.Explode();
    }
}