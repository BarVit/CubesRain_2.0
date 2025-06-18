using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private float _explosionRadius = 10f;
    private float _explosionForce = 300f;

    public void Explode()
    {
        foreach (Rigidbody rigidbody in GetExplodableObjects())
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> rigidbodies = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                rigidbodies.Add(hit.attachedRigidbody);

        return rigidbodies;
    }
}