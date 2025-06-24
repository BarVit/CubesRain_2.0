using UnityEngine;
using UnityEngine.Pool;
using System;

public class Spawner<T> where T: SpawnObject
{
    private T _prefab;
    private ObjectPool<T> _pool = null;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 100;
    private int _spawnedAll = 0;
    private int _created = 0;

    public event Action<SpawnObject> OnObjectReleased;
    public event Action<int> SpawnedAllChanged;
    public event Action<int> CreatedChanged;
    public event Action<int> ActiveOnSceneChanged;

    public Spawner(T prefab)
    {
        _prefab = prefab;
    }

    public void Initialize()
    {
        _pool ??= new ObjectPool<T>(
            createFunc: () => Create(_prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => GameObject.Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public T Get()
    {
        T obj = _pool.Get();

        _spawnedAll++;
        ActiveOnSceneChanged?.Invoke(_pool.CountActive);
        SpawnedAllChanged?.Invoke(_spawnedAll);
        obj.LifeTimeEnded += Realese;

        return obj;
    }

    private void Realese(SpawnObject obj)
    {
        obj.LifeTimeEnded -= Realese;
        OnObjectReleased?.Invoke(obj);
        _pool.Release((T)obj);
        ActiveOnSceneChanged?.Invoke(_pool.CountActive);
    }

    private T Create(T prefab)
    {
        _created++;
        CreatedChanged?.Invoke(_created);

        return GameObject.Instantiate(prefab);
    }
}