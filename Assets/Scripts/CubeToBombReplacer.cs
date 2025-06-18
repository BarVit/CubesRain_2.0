using UnityEngine;

public class CubeToBombReplacer : MonoBehaviour
{
    private ObjectPool _pool;
    private Spawner<Bomb> _bombSpawner;

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
        _bombSpawner = new Spawner<Bomb>(_pool);
    }

    private void OnEnable()
    {
        Cube.Destroyed += SpawnBomb;
    }

    private void OnDisable()
    {
        Cube.Destroyed += SpawnBomb;
    }

    public Spawner<Bomb> GetSpawner()
    {
        return _bombSpawner;
    }

    private void SpawnBomb(Rigidbody cube)
    {
        Bomb bomb = _bombSpawner.SpawnWithStartParams(cube);
        
        bomb.Explode();
    }
}