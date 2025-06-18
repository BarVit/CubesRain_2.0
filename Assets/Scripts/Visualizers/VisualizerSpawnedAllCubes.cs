using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VisualizerSpawnedAllCubes : MonoBehaviour
{
    [SerializeField] private CubesRain _rain;

    private TextMeshProUGUI _text;
    private Spawner<Cube> _cubeSpawner;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _cubeSpawner = _rain.GetSpawner();
        _cubeSpawner.spawnedAllChanged += Visualize;
    }

    private void OnDisable()
    {
        _cubeSpawner.spawnedAllChanged -= Visualize;
    }

    private void Visualize(int value)
    {
        _text.text = value.ToString();
    }
}