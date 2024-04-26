using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeFuse : MonoBehaviour
{
    [SerializeField] private float _pushingForce = 700F;
    [SerializeField] private float _pushingRadius = 3F;

    private Collider _collider = new();

    public float PushingForce => _pushingForce;
    public float PushingRadius => _pushingRadius;

    private void Awake()
    {
        if (TryGetComponent(out Collider collider))
        {
            _collider = collider;
        }
    }

    public void Undermine()
    {
        int fissileCubeLayer = 6;
        int targetLayer = 1 << fissileCubeLayer;
        int minColliders = 1;
        List<Collider> colliders = Physics.OverlapSphere(transform.position, _pushingRadius, targetLayer).ToList();
        colliders.Remove(_collider);

        if (colliders.Count >= minColliders)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(_pushingForce, transform.position, _pushingRadius);
                }
            }
        }
    }

    public void Init(float pushingForce, float pushingRadius)
    {
        _pushingForce = pushingForce;
        _pushingRadius = pushingRadius;
    }
}