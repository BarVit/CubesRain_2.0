using UnityEngine;
using System;

public abstract class Shape3D : MonoBehaviour
{
    public Action<Shape3D> LifeTimeEnded { get; internal set; }

    protected Coroutine Counter;

    public virtual void Init() { }
    public virtual void Init(Shape3D cube) { }
}