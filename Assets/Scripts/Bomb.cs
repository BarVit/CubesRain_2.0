using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer), typeof(Exploder), typeof(ColorFader))]
[RequireComponent(typeof(Rigidbody))]
public class Bomb : Shape3D
{
    private Rigidbody _rigidbody;
    private Material _material;
    private Exploder _exploder;
    private ColorFader _colorFader;
    private Color _originalColor = Color.black;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;
        _exploder = GetComponent<Exploder>();
        _colorFader = GetComponent<ColorFader>();
    }

    public override void Init(Shape3D cube)
    {
        Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

        transform.position = cube.transform.position;
        transform.rotation = cube.transform.rotation;
        _rigidbody.velocity = cubeRigidbody.velocity;
        _rigidbody.angularVelocity = cubeRigidbody.angularVelocity;
        _material.color = _originalColor;
    }

    public void Explode()
    {
        float minExplodeTime = 2f;
        float maxExplodeTime = 5f;
        float timeToExplode = Random.Range(minExplodeTime, maxExplodeTime);

        _colorFader.SetStartParams(_material.color, timeToExplode);
        Counter = StartCoroutine(CountToExplode(timeToExplode));
    }

    private IEnumerator CountToExplode(float time)
    {
        float timeToExplode = 0;
        
        while(timeToExplode < time)
        {
            timeToExplode += Time.deltaTime;
            _material.color = _colorFader.GetIntermediateColor(timeToExplode);

            yield return null;
        }

        _exploder.Explode();
        LifeTimeEnded?.Invoke(this);
    }
}