using System;

public static class MathUtils
{
    public static float MapPercentageToValue(float percentage, float minValue, float maxValue)
    {
        if (percentage < 0f || percentage > 1f)
        {
            throw new ArgumentOutOfRangeException("Percentage must be between 0 and 1.");
        }

        float range = maxValue - minValue;
        float scaledValue = minValue + (range * percentage);
        return scaledValue;
    }
}
