using TMPro;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TextMeshProUGUI _spawnedAllText;
    [SerializeField] private TextMeshProUGUI _createdText;
    [SerializeField] private TextMeshProUGUI _activeOnSceneText;

    private Pool<Shape3D> _pool;

    private void Start()
    {
        _pool = _spawner.GetPool();
        _pool.SpawnedAllChanged += VisualizeSpawnedAll;
        _pool.CreatedChanged += VisualizeCreated;
        _pool.ActiveOnSceneChanged += VisualizeActiveOnScene;
    }

    private void OnDestroy()
    {
        _pool.SpawnedAllChanged -= VisualizeSpawnedAll;
        _pool.CreatedChanged -= VisualizeCreated;
        _pool.ActiveOnSceneChanged -= VisualizeActiveOnScene;
    }

    protected void VisualizeSpawnedAll(int value)
    {
        _spawnedAllText.text = value.ToString();
    }

    protected void VisualizeCreated(int value)
    {
        _createdText.text = value.ToString();
    }

    protected void VisualizeActiveOnScene(int value)
    {
        _activeOnSceneText.text = value.ToString();
    }
}