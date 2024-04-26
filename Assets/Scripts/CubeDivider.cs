using UnityEngine;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private FissileCube _fissileCube;
    [SerializeField] private int _mimCubesWhenDividing = 2;
    [SerializeField] private int _maxCubesWhenDividing = 7;
    [SerializeField] private int _scaleDivider = 2;
    [SerializeField] private int _chanceDivider = 2;
    [SerializeField] private int _divisionChance = 100;

    private CubeFuse _cubeFuse = new ();

    public int DivisionChance => _divisionChance;

    public void Init(int divisionChance, Vector3 scale)
    {
        _divisionChance = divisionChance;
        transform.localScale = scale;

        if (TryGetComponent(out CubeFuse cubeFuse))
        {
            _cubeFuse = cubeFuse;
        }
    }

    public void Divide()
    {
        int cubesCount = RandomHelper.GetRandomNumber(_mimCubesWhenDividing, _maxCubesWhenDividing);

        for (int i = 0; i < cubesCount; i++)
        {
            float forceMultiplier = 1.5F;
            float radiusMultiplier = 1.5F;
            FissileCube fissileCube = Instantiate(_fissileCube, transform.position, Quaternion.identity);
            int chance = _divisionChance / _chanceDivider;
            Vector3 scale = transform.localScale / _scaleDivider;
            float pushingForce = _cubeFuse.PushingForce * forceMultiplier;
            float pushingRadius = _cubeFuse.PushingRadius * radiusMultiplier;
            fissileCube.Init(chance, scale, pushingForce, pushingRadius);
        }
    }
}