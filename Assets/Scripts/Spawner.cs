using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private Shape3D _prefab;

    protected Pool<Shape3D> Pool;

    private void Awake()
    {
        Pool = new Pool<Shape3D>(_prefab);
        Pool.Initialize();
    }

    public Pool<Shape3D> GetPool()
    {
        return Pool;
    }
}