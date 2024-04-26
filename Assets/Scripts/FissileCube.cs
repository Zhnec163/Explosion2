using UnityEngine;

[RequireComponent(typeof(CubeFuse), typeof(CubeDivider))]
public class FissileCube : MonoBehaviour
{
    private CubeFuse _cubeFuse;
    private CubeDivider _cubeDivider;

    public void Init(int chance, Vector3 scale, float pushingForce, float pushingRadius)
    {
        GetComponent<MeshRenderer>().material.color = RandomHelper.GetRandomColor();
        _cubeFuse.Init(pushingForce, pushingRadius);
        _cubeDivider.Init(chance, scale);
    }
    
    public void ProcessClick()
    {
        TryToSeparate();
    }

    private void TryToSeparate()
    {
        int minPercent = 0;
        int maxPercent = 100;
        int randomValue = RandomHelper.GetRandomNumber(minPercent, maxPercent);

        if (randomValue < _cubeDivider.DivisionChance)
        {
            _cubeDivider.Divide();
        }
        else
        {
            _cubeFuse.Undermine();
        }

        Destroy(gameObject);
    }
}
