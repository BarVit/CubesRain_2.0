using UnityEngine;
using System;

public abstract class SpawnObject : MonoBehaviour
{
    public Action<SpawnObject> LifeTimeEnded { get; internal set; }
}