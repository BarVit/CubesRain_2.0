using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class VisualizerCreated : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _pool.CreatedChanged += Visualize;
    }

    private void OnDisable()
    {
        _pool.CreatedChanged -= Visualize;
    }

    private void Visualize(int value)
    {
        _text.text = value.ToString();
    }
}