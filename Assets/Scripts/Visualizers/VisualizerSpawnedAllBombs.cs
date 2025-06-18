using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VisualizerSpawnedAllBombs : MonoBehaviour
{
    [SerializeField] private CubeToBombReplacer _replacer;

    private TextMeshProUGUI _text;
    private Spawner<Bomb> _bombSpawner;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _bombSpawner = _replacer.GetSpawner();
        _bombSpawner.spawnedAllChanged += Visualize;
    }

    private void OnDisable()
    {
        _bombSpawner.spawnedAllChanged -= Visualize;
    }

    private void Visualize(int value)
    {
        _text.text = value.ToString();
    }
}