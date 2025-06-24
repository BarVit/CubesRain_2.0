using UnityEngine;
using System.Collections;

public class VisualizerBombsStats : Visualizer
{
    [SerializeField] private CubeToBombReplacer _replacer;

    private Spawner<Bomb> _spawner;
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

        _spawner = _replacer.GetSpawner();
        _spawner.SpawnedAllChanged += VisualizeSpawnedAll;
        _spawner.CreatedChanged += VisualizeCreated;
        _spawner.ActiveOnSceneChanged += VisualizeActiveOnScene;
    }
}