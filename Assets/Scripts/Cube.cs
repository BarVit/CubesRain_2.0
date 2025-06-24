using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody), typeof(Renderer), typeof(ColorChanger))]
public class Cube : SpawnObject
{
    private Rigidbody _rigidbody;
    private Material _material;
    private ColorChanger _colorChanger;
    private Coroutine _counter;
    private bool _isFirstCollision = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFirstCollision && collision.collider.TryGetComponent<Plane>(out _))
        {
            _isFirstCollision = false;
            _colorChanger.SetRandomColor(_material);
            _counter = StartCoroutine(CountToDestroy());
        }
    }

    public void Init()
    {
        _isFirstCollision = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _colorChanger.SetOriginalColor(_material);
    }

    private IEnumerator CountToDestroy()
    {
        float minDestroyTime = 2f;
        float maxDestroyTime = 5f;
        WaitForSeconds waitForSeconds = new(Random.Range(minDestroyTime, maxDestroyTime));

        yield return waitForSeconds;

        LifeTimeEnded?.Invoke(this);
    }
}