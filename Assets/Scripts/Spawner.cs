using UnityEngine;

public class Spawner<T> where T : SpawnObject
{
    private ObjectPool _pool;
    private int _spawnedAll;

    public delegate void SpawnedAllChanged(int value);
    public SpawnedAllChanged spawnedAllChanged;

    public Spawner(ObjectPool pool)
    {
        _pool = pool;
    }

    public T Spawn()
    {
        T obj = (T)_pool.Get();

        _spawnedAll++;
        spawnedAllChanged?.Invoke(_spawnedAll);

        return obj;
    }

    public T SpawnWithStartParams(Rigidbody rigidbody)
    {
        T obj = (T)_pool.Get();
        Rigidbody newRigidbody = obj.GetComponent<Rigidbody>();

        _spawnedAll++;
        spawnedAllChanged?.Invoke(_spawnedAll);
        obj.transform.position = rigidbody.transform.position;
        obj.transform.rotation = rigidbody.transform.rotation;
        newRigidbody.velocity = rigidbody.velocity;
        newRigidbody.angularVelocity = rigidbody.angularVelocity;
        return obj;
    }
}