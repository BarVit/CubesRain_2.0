using TMPro;
using UnityEngine;

public abstract class Visualizer : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI TextSpawnedAll;
    [SerializeField] protected TextMeshProUGUI TextCreated;
    [SerializeField] protected TextMeshProUGUI TextActiveOnScene;

    protected void VisualizeSpawnedAll(int value)
    {
        TextSpawnedAll.text = value.ToString();
    }

    protected void VisualizeCreated(int value)
    {
        TextCreated.text = value.ToString();
    }

    protected void VisualizeActiveOnScene(int value)
    {
        TextActiveOnScene.text = value.ToString();
    }
}