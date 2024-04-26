using UnityEngine;
using Random = UnityEngine.Random;

public class RandomHelper : MonoBehaviour
{
    public static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    
    public static Color GetRandomColor()
    {
        float minRangeColor = 0F;
        float maxRangeColor = 255F;
        float r = Random.Range(minRangeColor, maxRangeColor) / maxRangeColor;
        float g = Random.Range(minRangeColor, maxRangeColor) / maxRangeColor;
        float b = Random.Range(minRangeColor, maxRangeColor) / maxRangeColor;
        int alpha = 1;
        return new Color(r, g, b, alpha);
    }
}