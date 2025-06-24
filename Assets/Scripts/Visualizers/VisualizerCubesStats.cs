using UnityEngine;
using System.Collections;

public class VisualizerCubesStats : Visualizer
{
    [SerializeField] private CubesRain _rain;

    private Spawner<Cube> _spawner;
    private Coroutine _waiter;

    private void Start()
    {
        _waiter = StartCoroutine(Assigner());
    }

    private void OnDestroy()
    {
        _spawner.SpawnedAllChanged -= VisualizeSpawnedAll;
        _spawner.CreatedChanged -= VisualizeCreated;
        _spawner.ActiveOnSceneChanged -= VisualizeActiveOnScene;
    }

    private IEnumerator Assigner()
    {
        float startTime = 0.01f;
        WaitForSeconds wait = new(startTime);

        yield return wait;

        _spawner = _rain.GetSpawner();
        _spawner.SpawnedAllChanged += VisualizeSpawnedAll;
        _spawner.CreatedChanged += VisualizeCreated;
        _spawner.ActiveOnSceneChanged += VisualizeActiveOnScene;
    }
}