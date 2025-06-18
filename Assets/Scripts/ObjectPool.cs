using UnityEngine;
using UnityEngine.Pool;
using System;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private SpawnObject _prefab;

    private ObjectPool<SpawnObject> _pool;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 100;
    private int _created = 0;

    public event Action<int> CreatedChanged;
    public event Action<int> ActiveOnSceneChanged;

    private void Awake()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        _pool = new ObjectPool<SpawnObject>(
            createFunc: () =>
            {
                _created++;
                CreatedChanged?.Invoke(_created);

                return Instantiate(_prefab);
            },
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public SpawnObject Get()
    {
        SpawnObject obj = _pool.Get();

        ActiveOnSceneChanged?.Invoke(_pool.CountActive);
        obj.LifeTimeEnded += Realese;
        return obj;
    }

    public void Realese(SpawnObject obj)
    {
        obj.LifeTimeEnded -= Realese;
        _pool.Release(obj);
        ActiveOnSceneChanged?.Invoke(_pool.CountActive);
    }
}