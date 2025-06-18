using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer), typeof(Exploder))]
public class Bomb : SpawnObject
{
    private Material _material;
    private Exploder _exploder;
    private Coroutine _counter;
    private float _alpha;
    private float _startAlpha;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _exploder = GetComponent<Exploder>();
        _startAlpha = _material.color.a;
    }

    public void Explode()
    {
        float minExplodeTime = 2f;
        float maxExplodeTime = 5f;
        float timeToExplode = Random.Range(minExplodeTime, maxExplodeTime);

        _counter = StartCoroutine(CountToExplode(timeToExplode));
    }

    private IEnumerator CountToExplode(float time)
    {
        float timeToExplode = 0;
        
        while(timeToExplode < time)
        {
            timeToExplode += Time.deltaTime;
            _alpha = Mathf.Lerp(_startAlpha, 0, timeToExplode / time);
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, _alpha);

            yield return null;
        }

        _exploder.Explode();
        LifeTimeEnded?.Invoke(this);
    }
}